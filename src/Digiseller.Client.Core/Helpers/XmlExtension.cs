using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Digiseller.Client.Core.Helpers
{
    public static class XmlExtension
    {
        #region Fields

        private static readonly XmlWriterSettings WriterSettings =
            new XmlWriterSettings {OmitXmlDeclaration = true, Indent = true};

        private static readonly XmlSerializerNamespaces Namespaces =
            new XmlSerializerNamespaces(new[] {new XmlQualifiedName("", "")});

        #endregion

        #region Methods

        public static string SerializeToXml<T>(this T obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            return DoSerialize(obj);
        }

        private static string DoSerialize<T>(T obj)
        {
            using (var ms = new MemoryStream())
            using (var writer = XmlWriter.Create(ms, WriterSettings))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj, Namespaces);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T DeserializeFromXml<T>(this string data)
            where T : class
        {
            if (string.IsNullOrEmpty(data))
                throw new NullReferenceException();

            return DoDeserialize<T>(data);
        }

        private static T DoDeserialize<T>(string data) where T : class
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(ms);
            }
        }

        #endregion
    }
}