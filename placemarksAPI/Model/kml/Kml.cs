using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    [XmlRoot("kml", Namespace = "http://www.opengis.net/kml/2.2")]
    public class Kml
    {
        [XmlElement("Document")]
        public Document Document { get; set; }
    }
}
