using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class HotSpot
    {
        [XmlAttribute("x")]
        public float? X { get; set; }

        [XmlAttribute("xunits")]
        public string? XUnits { get; set; }

        [XmlAttribute("y")]
        public float? Y { get; set; }

        [XmlAttribute("yunits")]
        public string? YUnits { get; set; }
    }
}
