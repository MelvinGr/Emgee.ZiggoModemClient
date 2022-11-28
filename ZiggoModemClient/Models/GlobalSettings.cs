using System.Xml.Serialization;

namespace ZiggoModemClient.Models
{
    [XmlRoot(ElementName = "GlobalSettings")]
    public class GlobalSettings
    {
        [XmlElement(ElementName = "AccessLevel")]
        public int AccessLevel { get; set; }

        [XmlElement(ElementName = "SwVersion")]
        public string SwVersion { get; set; }

        [XmlElement(ElementName = "CmProvisionMode")]
        public string CmProvisionMode { get; set; }

        [XmlElement(ElementName = "DsLite")]
        public int DsLite { get; set; }

        [XmlElement(ElementName = "GwProvisionMode")]
        public string GwProvisionMode { get; set; }

        [XmlElement(ElementName = "GWOperMode")]
        public string GWOperMode { get; set; }

        [XmlElement(ElementName = "ConfigVenderModel")]
        public string ConfigVenderModel { get; set; }

        [XmlElement(ElementName = "HideRemoteAccess")]
        public /*bool*/ string HideRemoteAccess { get; set; }

        [XmlElement(ElementName = "HideModemMode")]
        public /*bool*/ string HideModemMode { get; set; }

        [XmlElement(ElementName = "HideCustomerDhcpLanChange")]
        public int HideCustomerDhcpLanChange { get; set; }

        [XmlElement(ElementName = "ShowDDNS")]
        public /*bool*/ string ShowDDNS { get; set; }

        [XmlElement(ElementName = "OperatorId")]
        public string OperatorId { get; set; }

        [XmlElement(ElementName = "AccessDenied")]
        public string AccessDenied { get; set; }

        [XmlElement(ElementName = "LockedOut")]
        public string LockedOut { get; set; }

        [XmlElement(ElementName = "CountryID")]
        public int CountryID { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Interface")]
        public int Interface { get; set; }

        [XmlElement(ElementName = "operStatus")]
        public int OperStatus { get; set; }
    }
}
