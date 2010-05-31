using System.Web.Routing;

namespace Martin {

    public interface IActionFactory {
        IAction CreateAction<T>(RequestContext requestContext) where T : IAction;
    }
}