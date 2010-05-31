using System.Web;
using System.Web.Routing;

namespace Martin {

    public class ActionHandler<T> : IHttpHandler where T : IAction {

        public RequestContext Context { get; private set; }

        public bool IsReusable {
            get { return false; }
        }

        private ActionBuilder _actionBuilder;
        internal ActionBuilder ActionBuilder {
            get {
                if (_actionBuilder == null)
                    _actionBuilder = ActionBuilder.Current;
                return _actionBuilder;
            }
        }

        public ActionHandler(RequestContext requestContext) {
            Context = requestContext;
        }

        public void ProcessRequest(HttpContext context) {
            var action = ActionBuilder.Current.GetActionFactory().CreateAction<T>(Context);
            ActionInvoker.Execute(action, Context);
        }
    }
}