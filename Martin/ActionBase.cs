using System.Web;
using System.Web.Routing;

namespace Martin {

    public abstract class ActionBase : IAction, IContextAware {

        public RequestContext Context { get; set; }

        public HttpRequestBase Request {
            get { return Context.HttpContext.Request; }
        }

        public HttpResponseBase Response {
            get { return Context.HttpContext.Response; }
        }

        public T ValueOf<T>(string hashKey) {
            return ValueProvider.ValueOf<T>(Context, hashKey);
        }

        public virtual IResponse Get() { return new EmptyResponse(); }
        public virtual IResponse Post() { return new EmptyResponse(); }
        public virtual IResponse Put() { return new EmptyResponse(); }
        public virtual IResponse Delete() { return new EmptyResponse(); }

        #region IResponse Helpers

        public static TextResponse Text(string text) {
            return new TextResponse(text);
        }

        public static JsonResponse Json(object data) {
            return new JsonResponse(data);
        }

        public static XmlResponse Xml(object data) {
            return new XmlResponse(data);
        }

        public static FileResponse File(string path) {
            return new FileResponse(path);
        }

        public static EmptyResponse Empty() {
            return new EmptyResponse();
        }

        #endregion
    }
}