using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZiggoModemClient.Models
{
    [XmlRoot(ElementName = "cmstatus")]
    public class CmStatus
    {
        [XmlElement(ElementName = "provisioning_st")]
        public string ProvisioningSt { get; set; }

        [XmlElement(ElementName = "provisioning_st_num")]
        public int ProvisioningStNum { get; set; }

        [XmlElement(ElementName = "cm_comment")]
        public string CmComment { get; set; }

        [XmlElement(ElementName = "ds_num")]
        public int DsNum { get; set; }

        [XmlElement(ElementName = "downstream")]
        public List<CmStatusDownstream> Downstream { get; set; }

        [XmlElement(ElementName = "us_num")]
        public int UsNum { get; set; }

        [XmlElement(ElementName = "upstream")]
        public List<CmStatusUpstream> Upstream { get; set; }

        [XmlElement(ElementName = "cm_docsis_mode")]
        public string CmDocsisMode { get; set; }

        [XmlElement(ElementName = "cm_network_access")]
        public string CmNetworkAccess { get; set; }

        [XmlElement(ElementName = "NumberOfCpes")]
        public int NumberOfCpes { get; set; }

        [XmlElement(ElementName = "dMaxCpes")]
        public int DMaxCpes { get; set; }

        [XmlElement(ElementName = "bpiEnable")]
        public int BpiEnable { get; set; }

        [XmlElement(ElementName = "FileName")]
        public string FileName { get; set; }

        [XmlElement(ElementName = "serviceflow")]
        public List<CmStatusServiceflow> Serviceflow { get; set; }
    }

    [XmlRoot(ElementName = "downstream")]
    public class CmStatusDownstream
    {
        [XmlElement(ElementName = "freq")]
        public int Freq { get; set; }

        [XmlElement(ElementName = "mod")]
        public string Mod { get; set; }

        [XmlElement(ElementName = "chid")]
        public int Chid { get; set; }

        [XmlElement(ElementName = "state")]
        public int State { get; set; }

        [XmlElement(ElementName = "status")]
        public int Status { get; set; }

        [XmlElement(ElementName = "primarySettings")]
        public int PrimarySettings { get; set; }
    }

    [XmlRoot(ElementName = "upstream")]
    public class CmStatusUpstream
    {
        [XmlElement(ElementName = "usid")]
        public int Usid { get; set; }

        [XmlElement(ElementName = "freq")]
        public int Freq { get; set; }

        [XmlElement(ElementName = "power")]
        public int Power { get; set; }

        [XmlElement(ElementName = "srate")]
        public double Srate { get; set; }

        [XmlElement(ElementName = "state")]
        public int State { get; set; }
    }

    [XmlRoot(ElementName = "serviceflow")]
    public class CmStatusServiceflow
    {
        [XmlElement(ElementName = "Sfid")]
        public int Sfid { get; set; }

        [XmlElement(ElementName = "direction")]
        public int Direction { get; set; }

        [XmlElement(ElementName = "pMaxTrafficRate")]
        public int PMaxTrafficRate { get; set; }

        [XmlElement(ElementName = "pMaxTrafficBurst")]
        public int PMaxTrafficBurst { get; set; }

        [XmlElement(ElementName = "pMinReservedRate")]
        public int PMinReservedRate { get; set; }

        [XmlElement(ElementName = "pMaxConcatBurst")]
        public int PMaxConcatBurst { get; set; }

        [XmlElement(ElementName = "pSchedulingType")]
        public int PSchedulingType { get; set; }
    }
}
