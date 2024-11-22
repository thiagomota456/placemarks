using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using placemarksAPI.Model.kml;
using System.Xml.Serialization;
using System.Text;

namespace placemarksAPI.Service
{
    public static class ProcessKMLFile
    {
        private static string DataPath {  get; set; }
        private static readonly string Pattern = @"<description\s*/>";
        private static string KMLDataString {  get; set; }


        public static Kml Deserealize()
        {
            DataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, @"Data\DIRECIONADORES1.kml");
            KMLDataString = new StreamReader(DataPath, Encoding.UTF8).ReadToEnd();
            KMLDataString = Regex.Replace(KMLDataString, Pattern, "<description></description>");
            return DeserializeXml<Kml>(KMLDataString);
        }

        private static T DeserializeXml<T>(string xml)
        {
            XmlSerializer serializer = new(typeof(T));
            using StringReader reader = new(xml);
            object? result = serializer.Deserialize(reader) ?? throw new InvalidOperationException("Deserialization returned null.");
            return (T)result;
        }


    }
}
