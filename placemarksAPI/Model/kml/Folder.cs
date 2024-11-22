using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Folder
    {
        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("Placemark")]
        public List<Placemark>? Placemarks { get; set; }
    }
}
