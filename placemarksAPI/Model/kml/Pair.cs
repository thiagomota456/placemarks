using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Pair
    {
        [XmlElement("key")]
        public string? Key { get; set; }

        [XmlElement("styleUrl")]
        public string? StyleUrl { get; set; }
    }
}
