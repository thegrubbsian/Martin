using System.Web;
using System.Web.Routing;

namespace Martin {

    public class RouteAction<T> : IRouteHandler where T : IAction {

        public IHttpHandler GetHttpHandler(RequestContext requestContext) {
            return new ActionHandler<T>(requestContext);
        }
    }
}
