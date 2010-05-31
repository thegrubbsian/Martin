using System.Web.Routing;

namespace Martin {

    public interface IAction {
        RequestContext Context { get; set; }
        IResponse Get();
        IResponse Post();
        IResponse Put();
        IResponse Delete();
    }
}
