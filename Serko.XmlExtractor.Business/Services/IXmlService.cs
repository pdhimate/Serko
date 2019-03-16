namespace Serko.XmlExtractor.Business.Services
{
    public interface IXmlService
    {
        T TryDeserialize<T>(string xml);
        string ExtractXmlIsland(string text, string xmlTagName);
    }
}