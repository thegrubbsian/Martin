using System;
using System.Web.Routing;

namespace Martin {

    public class DefaultActionFactory : IActionFactory {

        public IAction CreateAction<T>(RequestContext requestContext) where T : IAction {
            var action = Activator.CreateInstance<T>();
            action.Context = requestContext;
            return action;
        }
    }
}