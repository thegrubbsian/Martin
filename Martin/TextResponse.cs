using System.Web.Routing;

namespace Martin {

    public class TextResponse : IResponse {

        private readonly string _text = string.Empty;

        public string ContentType { get { return "text/plain"; } }

        public TextResponse(string text) {
            _text = text;
        }

        public void Respond(RequestContext requestContext) {
            requestContext.HttpContext.Response.Write(_text);
        }
    }
}