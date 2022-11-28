using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZiggoModemClient.Models;

namespace ZiggoModemClient
{
    public interface IZiggoModemClient
    {
        Task<bool> Init(string password);
        Task<LanUserTable> GetLanUserTable();
        Task<DownstreamTable> GetDownstreamTable();
        Task<UpstreamTable> GetUpstreamTable();
        Task<SignalTable> GetSignalTable();
        Task<EventLogTable> GetEventLogTable();
        Task<CmStatus> GetStatus();
        Task<GlobalSettings> GetGlobalSettings();
    }

    public class ZiggoModemClient : IDisposable, IZiggoModemClient
    {
        private const string GetterUrl = "/xml/getter.xml";
        private const string SetterUrl = "/xml/setter.xml";
        private const string LoginPageUrl = "/common_page/login.html";

        private readonly CookieContainer _cookieContainer;
        private readonly HttpClient _httpClient;

        private string _sid;

        private string SessionToken => _cookieContainer.GetAllCookies()["sessionToken"]?.Value;

        public ZiggoModemClient(string ipAddress)
        {
            _cookieContainer = new CookieContainer();
            _httpClient = new HttpClient(new HttpClientHandler { CookieContainer = _cookieContainer }, true) { BaseAddress = new Uri("http://" + ipAddress) };
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36");
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        public async Task<bool> Init(string password)
        {
            // We just need the sessionToken cookie
            var loginPageResponse = await _httpClient.GetAsync(LoginPageUrl);
            if (!loginPageResponse.IsSuccessStatusCode || SessionToken == null)
                return false;

            using var sha256 = SHA256.Create();
            var passwordHash = Convert.ToHexString(sha256.ComputeHash(Encoding.UTF8.GetBytes(password))).ToLower();

            var response = await PostForm(SetterUrl, new Dictionary<string, string>
            {
                ["token"] = SessionToken,
                ["fun"] = ((int)FunctionIds.Login).ToString(),
                ["Username"] = "NULL",
                ["Password"] = passwordHash
            });

            if (response.StatusCode != HttpStatusCode.OK || !response.Content.Contains("successful;SID="))
                return false;

            _sid = response.Content.Split('=').Last();
            //_httpClientHandler.CookieContainer.Add(new Cookie("SID", sid, "/", _httpClient.BaseAddress.Host));

            return true;
        }

        public Task<LanUserTable> GetLanUserTable()
        {
            return DoGet<LanUserTable>(FunctionIds.LanUserTable);
        }

        public Task<DownstreamTable> GetDownstreamTable()
        {
            return DoGet<DownstreamTable>(FunctionIds.CmDownstream);
        }

        public Task<UpstreamTable> GetUpstreamTable()
        {
            return DoGet<UpstreamTable>(FunctionIds.CmUpstream);
        }

        public Task<SignalTable> GetSignalTable()
        {
            return DoGet<SignalTable>(FunctionIds.CmSignal);
        }

        public Task<EventLogTable> GetEventLogTable()
        {
            return DoGet<EventLogTable>(FunctionIds.MgrEventlog);
        }

        public Task<CmStatus> GetStatus()
        {
            return DoGet<CmStatus>(FunctionIds.CmStatus);
        }

        public Task<GlobalSettings> GetGlobalSettings()
        {
            return DoGet<GlobalSettings>(FunctionIds.GlobalSettings);
        }

        private async Task<T> DoGet<T>(FunctionIds functionId) where T : class
        {
            if (string.IsNullOrEmpty(_sid))
                throw new Exception("Init() first!");

            var response = await PostForm(GetterUrl, new Dictionary<string, string>
            {
                ["token"] = SessionToken,
                ["fun"] = ((int)functionId).ToString()
            });

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"Error: {(int)response.StatusCode} - {response.Content}");

            using var reader = new StringReader(response.Content);
            return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
        }

        private async Task<(HttpStatusCode StatusCode, string Content)> PostForm(string address, Dictionary<string, string> obj)
        {
            var httpResponse = await _httpClient.PostAsync(address, new FormUrlEncodedContent(obj));
            return (httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());
        }

        private enum FunctionIds
        {
            GlobalSettings = 1,
            CmDownstream = 10,
            CmUpstream = 11,
            CmSignal = 12,
            MgrEventlog = 13,
            Login = 15,
            LanUserTable = 123,
            CmStatus = 144
        }
    }
}
