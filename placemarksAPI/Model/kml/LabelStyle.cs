using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class LabelStyle
    {
        [XmlElement("scale")]
        public float? Scale { get; set; }
    }
}
