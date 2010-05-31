using System.Web.Routing;

namespace Martin {

    public interface IContextAware {
        RequestContext Context { get; }
        T ValueOf<T>(string hashKey);
    }
}
