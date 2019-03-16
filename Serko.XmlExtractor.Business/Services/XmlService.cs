using Serko.XmlExtractor.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Serko.XmlExtractor.Business.Services
{
    public class XmlService : IXmlService
    {
        public string ExtractXmlIsland(string text, string xmlTagName)
        {
            var regexPattern = $@"<{xmlTagName}>[\s\S]*<\/{xmlTagName}>";
            var match = Regex.Match(text, regexPattern);
            return match.Value;
        }

        public T TryDeserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            T result;
            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    result = (T)serializer.Deserialize(reader);
                }
                catch (Exception)
                {
                    // TODO: Log exception
                    return default(T);
                }
            }
            return result;
        }
    }
}
