using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZiggoModemClient.Models
{
    [XmlRoot(ElementName = "upstream_table")]
    public class UpstreamTable
    {
        [XmlElement(ElementName = "us_num")]
        public int UsNum { get; set; }

        [XmlElement(ElementName = "upstream")]
        public List<UpstreamTableUpstream> Upstream { get; set; }
    }

    [XmlRoot(ElementName = "upstream")]
    public class UpstreamTableUpstream
    {
        [XmlElement(ElementName = "usid")]
        public int Usid { get; set; }

        [XmlElement(ElementName = "freq")]
        public int Freq { get; set; }

        [XmlElement(ElementName = "power")]
        public int Power { get; set; }

        [XmlElement(ElementName = "srate")]
        public double Srate { get; set; }

        [XmlElement(ElementName = "mod")]
        public string Mod { get; set; }

        [XmlElement(ElementName = "ustype")]
        public int Ustype { get; set; }

        [XmlElement(ElementName = "t1Timeouts")]
        public int T1Timeouts { get; set; }

        [XmlElement(ElementName = "t2Timeouts")]
        public int T2Timeouts { get; set; }

        [XmlElement(ElementName = "t3Timeouts")]
        public int T3Timeouts { get; set; }

        [XmlElement(ElementName = "t4Timeouts")]
        public int T4Timeouts { get; set; }

        [XmlElement(ElementName = "channeltype")]
        public string Channeltype { get; set; }

        [XmlElement(ElementName = "messageType")]
        public int MessageType { get; set; }
    }
}
