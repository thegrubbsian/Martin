using System.Web.Routing;

namespace Martin {

    public static class Config {

        public static void AddAction<T>(string routeUrl) where T : IAction {
            RouteTable.Routes.Add(new Route(routeUrl, new RouteAction<T>()));
        }

        public static void SetActionFactory(IActionFactory actionFactory) {
            ActionBuilder.Current.SetActionFactory(actionFactory);
        }
    }
}
