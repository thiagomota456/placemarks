using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    [XmlRoot("Placemark")]
    public class Placemark
    {
        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("description")]
        public string? Description { get; set; }

        [XmlElement("styleUrl")]
        public string? StyleUrl { get; set; }

        [XmlElement("ExtendedData")]
        public ExtendedData? ExtendedData { get; set; }

        [XmlElement("Point")]
        public Point? Point { get; set; }
    }
}
