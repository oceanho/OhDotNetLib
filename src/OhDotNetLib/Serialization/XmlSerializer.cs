using System.IO;

using SystemXmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace OhDotNetLib.Serialization
{
    public class XmlSerializer
    {
        public static string Serializer(object obj)
        {
            var _str = string.Empty;
            var xmlserializer = new SystemXmlSerializer(obj.GetType());
            using (var stream = new MemoryStream())
            {
                xmlserializer.Serialize(stream, obj);
                using (var reader = new StreamReader(stream))
                {
                    stream.Position = 0;
                    _str = reader.ReadToEnd();
                }
            }
            return _str;
        }

        public static TObject Deserializer<TObject>(string xml)
        {
            var _obj = default(TObject);
            var xmlserializer = new SystemXmlSerializer(typeof(TObject));
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(xml);
                    writer.Flush();
                    stream.Position = 0;
                    _obj = (TObject)xmlserializer.Deserialize(stream);
                }
            }
            return _obj;
        }
    }
}
