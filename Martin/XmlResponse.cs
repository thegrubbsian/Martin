using System.Web.Routing;
using System.Xml.Serialization;

namespace Martin {

    public class XmlResponse : IResponse {
        
        private readonly object _data;

        public string ContentType { get { return "text/xml"; } }

        public XmlResponse(object data) {
            _data = data;
        }

        public void Respond(RequestContext requestContext) {
            var xs = new XmlSerializer(_data.GetType());
            requestContext.HttpContext.Response.ContentType = ContentType;
            xs.Serialize(requestContext.HttpContext.Response.Output, _data);
        }
    }
}