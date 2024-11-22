using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class HotSpot
    {
        [XmlElement("x")]
        public float? X { get; set; }

        [XmlElement("xunits")]
        public string? XUnits { get; set; }

        [XmlElement("y")]
        public float? Y { get; set; }

        [XmlElement("yunits")]
        public string? YUnits { get; set; }
    }
}
