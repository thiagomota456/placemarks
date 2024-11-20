using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Style
    {
        [XmlAttribute("id")]
        public string? Id { get; set; }

        [XmlElement("IconStyle")]
        public IconStyle? IconStyle { get; set; }

        [XmlElement("LabelStyle")]
        public LabelStyle? LabelStyle { get; set; }
    }
}
