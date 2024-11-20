using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class StyleMap
    {
        [XmlAttribute("id")]
        public string? Id { get; set; }

        [XmlElement("Pair")]
        public Pair[]? Pairs { get; set; }
    }
}
