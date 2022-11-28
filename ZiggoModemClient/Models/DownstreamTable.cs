using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZiggoModemClient.Models
{
    [XmlRoot(ElementName = "downstream_table")]
    public class DownstreamTable
    {
        [XmlElement(ElementName = "ds_num")]
        public int DsNum { get; set; }

        [XmlElement(ElementName = "downstream")]
        public List<DownstreamTableDownstream> Downstream { get; set; }
    }

    [XmlRoot(ElementName = "downstream")]
    public class DownstreamTableDownstream
    {
        [XmlElement(ElementName = "freq")]
        public int Freq { get; set; }

        [XmlElement(ElementName = "pow")]
        public int Pow { get; set; }

        [XmlElement(ElementName = "snr")]
        public int Snr { get; set; }

        [XmlElement(ElementName = "mod")]
        public string Mod { get; set; }

        [XmlElement(ElementName = "chid")]
        public int Chid { get; set; }

        [XmlElement(ElementName = "RxMER")]
        public double RxMER { get; set; }

        [XmlElement(ElementName = "PreRs")]
        public double PreRs { get; set; }

        [XmlElement(ElementName = "PostRs")]
        public int PostRs { get; set; }

        [XmlElement(ElementName = "IsQamLocked")]
        public int IsQamLocked { get; set; }

        [XmlElement(ElementName = "IsFECLocked")]
        public int IsFECLocked { get; set; }

        [XmlElement(ElementName = "IsMpegLocked")]
        public int IsMpegLocked { get; set; }
    }
}
