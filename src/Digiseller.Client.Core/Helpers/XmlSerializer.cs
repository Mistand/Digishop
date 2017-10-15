using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Digiseller.Client.Core.Interfaces;

namespace Digiseller.Client.Core.Helpers
{
    public class XmlSerializer<TRequest, TResponse> : ISerializer<TRequest, TResponse>
    {
        private readonly XmlWriterSettings _writerSettings =
            new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };

        private readonly XmlSerializerNamespaces _namespaces =
            new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });

        public Task<TResponse> Deserialize(string data)
        {
            return Task.Run(() => 
            {
                if (string.IsNullOrEmpty(data))
                    throw new NullReferenceException();

                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                {
                    var serializer = new XmlSerializer(typeof(TResponse));
                    return (TResponse)serializer.Deserialize(ms);
                }
            });
        }

        public Task<HttpContent> Serialize(TRequest obj)
        {
            return Task.Run(() => {
                if (obj == null)
                    throw new NullReferenceException();

                using (var ms = new MemoryStream())
                using (var writer = XmlWriter.Create(ms, _writerSettings))
                {
                    var serializer = new XmlSerializer(typeof(TRequest));
                    serializer.Serialize(writer, obj, _namespaces);
                    string serialized = Encoding.UTF8.GetString(ms.ToArray());
                    return new StringContent(serialized, Encoding.UTF8, "text/xml") as HttpContent;
                }
            });
        }
    }
}
