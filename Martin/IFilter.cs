using System.Web.Routing;

namespace Martin {

    public interface IFilter  {
        RequestContext Context { get; set; }
        void BeforeExecute();
        void AfterExecute();
    }
}
