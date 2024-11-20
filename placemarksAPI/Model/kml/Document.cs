using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Document
    {
        [XmlElement("name")]
        public string? Name { get; set; }

        [XmlElement("description", IsNullable = true)]
        public string? Description { get; set; } = ""; // Define valor padrão para evitar problemas

        [XmlElement("Style")]
        public List<Style>? Styles { get; set; }

        [XmlElement("StyleMap")]
        public List<StyleMap>? StyleMaps { get; set; }

        [XmlElement("Folder")]
        public Folder? Folder { get; set; }
    }
}
