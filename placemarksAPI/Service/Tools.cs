using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Serialization;
using System.Xml;

namespace placemarksAPI.Service
{
    public static class Tools
    {
        private static readonly Random Rand = new Random();

        public static string ConvertObjectToJson(Object value)
        {
            var option = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(value, option);
        }

        public static string SerializeToXml<T>(T obj)
        {
            XmlSerializer serializer = new(typeof(T));
            XmlWriterSettings settings = new()
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = new System.Text.UTF8Encoding(false)
            };

            using StringWriter stringWriter = new();
            using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings);

            serializer.Serialize(xmlWriter, obj);
            return stringWriter.ToString();
        }

        public static void WriteString(string value, string? path = "", string? namefile = "")
        {
            if (path == String.Empty) 
            {
                path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            }

            if (namefile == String.Empty)
            {
                namefile = "File" + Rand.Next();
            }

            File.WriteAllText(Path.Combine(path!, namefile!), value);
        }
    }
}
