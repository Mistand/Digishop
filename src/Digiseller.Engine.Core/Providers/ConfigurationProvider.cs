using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Digiseller.Engine.Core.Providers
{
    public class JsonConfProvider : IConfProvider
    {
        private readonly string _filePath;
        public JsonConfProvider()
        {
            _filePath = "appsettings.json";
        }

        public T Get<T>()
        {
            var fileData = System.IO.File.ReadAllText(_filePath);
            var json = JObject.Parse(fileData)[typeof(T).Name].ToString();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Save(object obj)
        {
            var fileData = System.IO.File.ReadAllText(_filePath);
            var json = JObject.Parse(fileData);
            json = json.SetPropertyContent(obj);
            //json[obj.GetType().Name] = JsonConvert.SerializeObject(obj);
            System.IO.File.WriteAllText(_filePath, json.ToString(Formatting.Indented));
        }
        
        
    }

    public static class JsonConfProviderExtension
    {
        public static JObject SetPropertyContent(this JObject source, object content)
        {
            var prop = source.Property(content.GetType().Name);

            if (prop == null)
            {
                prop = new JProperty(content.GetType().Name, JObject.FromObject(content));

                source.Add(prop);
            }
            else
            {
                prop.Value = JToken.FromObject(content);
            }

            return source;
        }
    }

    public interface IConfProvider
    {
        T Get<T>();
        void Save(object obj);
    }
}

