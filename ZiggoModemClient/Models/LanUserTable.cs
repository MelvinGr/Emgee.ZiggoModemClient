using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZiggoModemClient.Models
{
    [XmlRoot(ElementName = "LanUserTable")]
    public class LanUserTable
    {
        [XmlElement(ElementName = "Ethernet")]
        public LanUserTableEthernet Ethernet { get; set; }

        [XmlElement(ElementName = "WIFI")]
        public LanUserTableWiFi WiFi { get; set; }

        [XmlElement(ElementName = "totalClient")]
        public int TotalClient { get; set; }

        [XmlElement(ElementName = "Customer")]
        public string Customer { get; set; }
    }

    [XmlRoot(ElementName = "Ethernet")]
    public class LanUserTableEthernet
    {
        [XmlElement(ElementName = "clientinfo")]
        public List<LanUserTableClientInfo> ClientInfo { get; set; }
    }

    [XmlRoot(ElementName = "WIFI")]
    public class LanUserTableWiFi
    {
        [XmlElement(ElementName = "clientinfo")]
        public List<LanUserTableClientInfo> ClientInfo { get; set; }
    }

    [XmlRoot(ElementName = "clientinfo")]
    public class LanUserTableClientInfo
    {
        [XmlElement(ElementName = "interface")]
        public string Interface { get; set; }

        [XmlElement(ElementName = "IPv4Addr")]
        public string IPv4Addr { get; set; }

        /*[XmlElement(ElementName = "xmlhostname")]
        public object Xmlhostname { get; set; }

        [XmlElement(ElementName = "xmlicon")]
        public object Xmlicon { get; set; }*/

        [XmlElement(ElementName = "index")]
        public int Index { get; set; }

        [XmlElement(ElementName = "interfaceid")]
        public int InterfaceId { get; set; }

        [XmlElement(ElementName = "hostname")]
        public string Hostname { get; set; }

        [XmlElement(ElementName = "MACAddr")]
        public string MacAddr { get; set; }

        [XmlElement(ElementName = "method")]
        public int Method { get; set; }

        [XmlElement(ElementName = "leaseTime")]
        public string LeaseTime { get; set; }

        [XmlElement(ElementName = "speed")]
        public int Speed { get; set; }

        [XmlElement(ElementName = "IPv6Addr")]
        public string IPv6Addr { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(IPv6Addr)
                ? $"{Hostname} = {IPv4Addr} ({MacAddr})"
                : $"{Hostname} = {IPv4Addr}, {IPv6Addr} ({MacAddr})";
        }
    }
}
