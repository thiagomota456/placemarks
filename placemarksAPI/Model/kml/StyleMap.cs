using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class StyleMap
    {
        [XmlElement("id")]
        public string? Id { get; set; }

        [XmlElement("Pair")]
        public Pair[]? Pairs { get; set; }
    }
}
