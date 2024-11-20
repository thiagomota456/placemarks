using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Icon
    {
        [XmlElement("href")]
        public string? Href { get; set; }
    }
}
