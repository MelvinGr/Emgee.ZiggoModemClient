using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZiggoModemClient.Models
{
    [XmlRoot(ElementName = "eventlog_table")]
    public class EventLogTable
    {
        [XmlElement(ElementName = "eventlog")]
        public List<EventLogTableEventLog> EventLog { get; set; }

        [XmlElement(ElementName = "wifieventlog")]
        public List<EventLogTableWifiEventLog> WifiEventLog { get; set; }
    }

    [XmlRoot(ElementName = "eventlog")]
    public class EventLogTableEventLog
    {
        [XmlElement(ElementName = "prior")]
        public string Prior { get; set; }

        [XmlElement(ElementName = "text")]
        public string Text { get; set; }

        [XmlElement(ElementName = "time")]
        public string Time { get; set; }

        [XmlElement(ElementName = "t")]
        public int T { get; set; }
    }

    [XmlRoot(ElementName = "wifieventlog")]
    public class EventLogTableWifiEventLog
    {
        [XmlElement(ElementName = "prior")]
        public string Prior { get; set; }

        [XmlElement(ElementName = "text")]
        public string Text { get; set; }

        [XmlElement(ElementName = "time")]
        public string Time { get; set; }

        [XmlElement(ElementName = "t")]
        public int T { get; set; }
    }
}
