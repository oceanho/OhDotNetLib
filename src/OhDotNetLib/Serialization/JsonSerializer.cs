
using System;

namespace OhDotNetLib.Serialization
{
    public class JsonSerializer
    {
        public static string Serializer(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static TObject Deserializer<TObject>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TObject>(json);
        }
    }
}
