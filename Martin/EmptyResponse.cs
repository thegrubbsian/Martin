using System.Web.Routing;

namespace Martin {

    public class EmptyResponse : IResponse {
        public string ContentType { get { return "text/text"; } }
        public void Respond(RequestContext requestContext) {
            requestContext.HttpContext.Response.Write(string.Empty);
        }
    }
}