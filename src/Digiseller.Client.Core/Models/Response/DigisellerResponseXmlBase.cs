using System.Xml.Serialization;
using Digiseller.Client.Core.Interfaces;

namespace Digiseller.Client.Core.Models.Response
{
    public class DigisellerResponseXmlBase : IDigisellerResponseBase
    {
        [XmlElement(ElementName = "retval")]
        public int Retval { get; set; }

        [XmlElement(ElementName = "retdesc")]
        public string Retdesc { get; set; }

        public int GetRequestStatusCode()
        {
            return Retval;
        }

        public string GetErrorMessage()
        {
            return Retdesc;
        }
    }
}
