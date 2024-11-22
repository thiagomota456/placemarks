using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Style
    {
        [XmlElement("id")]
        public string? Id { get; set; }

        [XmlElement("IconStyle")]
        public IconStyle? IconStyle { get; set; }

        [XmlElement("LabelStyle")]
        public LabelStyle? LabelStyle { get; set; }
    }
}
