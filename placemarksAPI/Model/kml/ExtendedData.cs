using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class ExtendedData
    {
        [XmlElement("Data")]
        public Data[]? Data { get; set; }
    }
}
