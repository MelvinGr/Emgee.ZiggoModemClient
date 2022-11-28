using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ZiggoModemClient.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var modemIp = args.Length == 1 ? args[0] : "192.168.178.1";

            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddAuthorization();
            builder.Services.AddScoped<IZiggoModemClient>(_ => new ZiggoModemClient(modemIp));

            var app = builder.Build();
            //app.UseAuthorization();

            app.MapGet("/LanUsers", async (HttpContext httpContext) =>
            {
                var ziggoModemClient = httpContext.RequestServices.GetService<IZiggoModemClient>();

                var pw = httpContext.Request.Query["pw"];
                if (string.IsNullOrEmpty(pw))
                    return new { error = "Missing pw argument" };

                var initSuccess = await ziggoModemClient!.Init(pw);
                if (!initSuccess)
                    return new { error = "Error while logging in" };

                var ret = await ziggoModemClient.GetLanUserTable();
                return (object)ret; // cast because of previous return types
            });

            app.Run();
        }
    }
}
