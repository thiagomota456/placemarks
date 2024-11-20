﻿using System.Xml.Serialization;

namespace placemarksAPI.Model.kml
{
    public class Data
    {
        [XmlAttribute("name")]
        public string? Name { get; set; }

        [XmlElement("value")]
        public string? Value { get; set; }
    }
}
