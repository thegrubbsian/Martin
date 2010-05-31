using System.Web.Routing;

namespace Martin {

    public interface IResponse {
        string ContentType { get; }
        void Respond(RequestContext requestContext);
    }
}
