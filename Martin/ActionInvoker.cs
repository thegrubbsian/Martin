using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Routing;

namespace Martin {

    public static class ActionInvoker {

        public static void Execute(IAction action, RequestContext requestContext) {

            var httpVerb = (HttpVerbs)Enum.Parse(typeof(HttpVerbs), action.Context.HttpContext.Request.HttpMethod, true);

            if (!HasHttpMethod(action, httpVerb))
                throw new ApplicationException("The HTTP Verb '" + Enum.GetName(typeof(HttpVerbs), httpVerb) + "' did not have a matching method on the specified action.");

            RunPreExecutionFilters(action, httpVerb);

            switch (httpVerb) {
                case HttpVerbs.GET:
                    action.Get().Respond(requestContext);
                    break;
                case HttpVerbs.POST:
                    action.Post().Respond(requestContext);
                    break;
                case HttpVerbs.PUT:
                    action.Put().Respond(requestContext);
                    break;
                case HttpVerbs.DELETE:
                    action.Delete().Respond(requestContext);
                    break;
            }

            RunPostExecutionFilters(action, httpVerb);
        }

        private static List<IFilter> GetFilters(IAction action, HttpVerbs httpVerb) {
            var methodInfo = GetMethod(action, httpVerb);
            return methodInfo.GetCustomAttributes(typeof(IFilter), false).Select(x => (IFilter)x).ToList();
        }

        private static MethodInfo GetMethod(IAction action, HttpVerbs httpVerb) {
            return action.GetType().GetMethods().ToList().Find(
                x => x.Name.ToUpperInvariant() == Enum.GetName(typeof(HttpVerbs), httpVerb));
        }

        private static void RunPreExecutionFilters(IAction action, HttpVerbs httpVerb) {
            var filters = GetFilters(action, httpVerb);
            filters.ForEach(x => {
                                x.Context = action.Context;
                                x.BeforeExecute();
                            });
        }

        private static void RunPostExecutionFilters(IAction action, HttpVerbs httpVerb) {
            var filters = GetFilters(action, httpVerb);
            filters.ForEach(x => {
                                x.Context = action.Context;
                                x.AfterExecute();
                            });
        }

        private static bool HasHttpMethod(IAction action, HttpVerbs httpVerb) {
            return action.GetType().GetMethods().ToList().Find(
                       x => x.Name.ToLowerInvariant() == Enum.GetName(typeof(HttpVerbs), httpVerb).ToLowerInvariant()) != null;
        }
    }
}