using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Point
    {
        [XmlElement("coordinates")]
        public string? Coordinates { get; set; }
    }
}
