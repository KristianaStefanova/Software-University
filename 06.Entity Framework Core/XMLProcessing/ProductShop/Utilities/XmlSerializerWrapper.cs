using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public static class XmlSerializerWrapper
    {
        public static T? Deserialize<T>(string inputXml, string rootAttributeName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootAttributeName);
            XmlSerializer xmlSerializer
                = new XmlSerializer(typeof(T), xmlRootAttribute);

            using StringReader stringReader = new StringReader(inputXml);
            T? importDtos = (T?)xmlSerializer.Deserialize(stringReader);

            return importDtos;
        }

        public static T? Deserialize<T>(Stream inputStream, string rootAttributeName)
        {
            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute(rootAttributeName);
            XmlSerializer xmlSerializer
                = new XmlSerializer(typeof(T), xmlRootAttribute);

            T? importDtos = (T?)xmlSerializer.Deserialize(inputStream);

            return importDtos;
        }

        public static string Serialize<T>(T objectToSerialize, string rootAttributeName, IDictionary<string, string>? namespaces = null)
        {
            StringBuilder result = new StringBuilder();

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();

            if(namespaces != null)
            {
                foreach (KeyValuePair<string, string> ns in namespaces)
                {
                    xmlNamespaces.Add(ns.Key, ns.Value);
                }
            }
            else
            {
                xmlNamespaces.Add(string.Empty, string.Empty);
            }

            XmlRootAttribute xmlRootAttribute = 
                new XmlRootAttribute(rootAttributeName);

            XmlSerializer xmlSerializer
                = new XmlSerializer(typeof(T), xmlRootAttribute);

            using StringWriter stringWriter = new StringWriter(result);
            xmlSerializer.Serialize(stringWriter, objectToSerialize, xmlNamespaces);

            return result.ToString().TrimEnd();
        }

        public static void Serialize<T>(T objectToSerialize, string rootAttributeName,
            Stream serializationStream, IDictionary<string, string>? namespaces = null)
        {
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();

            if (namespaces != null)
            {
                foreach (KeyValuePair<string, string> ns in namespaces)
                {
                    xmlNamespaces.Add(ns.Key, ns.Value);
                }
            }
            else
            {
                xmlNamespaces.Add(string.Empty, string.Empty);
            }

            XmlRootAttribute xmlRootAttribute =
                new XmlRootAttribute(rootAttributeName);

            XmlSerializer xmlSerializer
                = new XmlSerializer(typeof(T), xmlRootAttribute);

            xmlSerializer.Serialize(serializationStream, objectToSerialize, xmlNamespaces);
        }
    }
}
