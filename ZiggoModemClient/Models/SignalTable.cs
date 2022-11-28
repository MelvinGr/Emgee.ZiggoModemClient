using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZiggoModemClient.Models
{
    [XmlRoot(ElementName = "signal_table")]
    public class SignalTable
    {
        [XmlElement(ElementName = "sig_num")]
        public int SigNum { get; set; }

        [XmlElement(ElementName = "signal")]
        public List<SignalTableSignal> Signal { get; set; }
    }

    [XmlRoot(ElementName = "signal")]
    public class SignalTableSignal
    {
        [XmlElement(ElementName = "dsid")]
        public int Dsid { get; set; }

        [XmlElement(ElementName = "unerrored")]
        public double Unerrored { get; set; }

        [XmlElement(ElementName = "correctable")]
        public int Correctable { get; set; }

        [XmlElement(ElementName = "uncorrectable")]
        public int Uncorrectable { get; set; }
    }
}
