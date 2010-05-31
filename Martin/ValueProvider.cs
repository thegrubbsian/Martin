using System;
using System.Web.Routing;

namespace Martin {

    public static class ValueProvider {

        public static T ValueOf<T>(RequestContext requextContext, string hashKey) {

            var obj = default(T);

            if (requextContext.RouteData.Values.ContainsKey(hashKey))
                obj = (T)Convert.ChangeType(requextContext.RouteData.Values[hashKey], typeof(T));
            else if (requextContext.HttpContext.Request[hashKey] != null)
                obj = (T)Convert.ChangeType(requextContext.HttpContext.Request[hashKey], typeof(T));

            return obj;
        }
    }
}
