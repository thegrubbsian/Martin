using System;
using System.Collections;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace Martin {

    public class JsonResponse : IResponse {

        private readonly object _data;

        public string ContentType { get { return "text/json"; } }

        public JsonResponse(object data) {
            if (data is IEnumerable)
                throw new ApplicationException("Security Warning: Arrays should not be used as the top level container for JSON packages.");
            _data = data;
        }

        public void Respond(RequestContext requestContext) {
            var serializer = new JavaScriptSerializer();
            requestContext.HttpContext.Response.Write(serializer.Serialize(_data));
        }
    }
}