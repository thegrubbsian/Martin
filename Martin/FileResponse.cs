using System;
using System.IO;
using System.Web.Routing;

namespace Martin {

    public class FileResponse : IResponse {
        
        private readonly string _path;

        public string ContentType {
            get {
                if (!String.IsNullOrEmpty(_path)) {
                    // get the content type from the registry
                    var ext = System.IO.Path.GetExtension(_path).ToLower();
                    var regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
                    // if the extension is not in the registry it could be added manually on the server
                    if (regKey != null && regKey.GetValue("Content Type") != null) {
                        return regKey.GetValue("Content Type").ToString();
                    }
                }
                return "application/unknown";
            }
        }

        public FileResponse(string path) {
            _path = path;
        }

        public void Respond(RequestContext requestContext) {
            var info = new FileInfo(_path);
            requestContext.HttpContext.Response.ContentType = ContentType;
            requestContext.HttpContext.Response.Write(info.Extension);
        }
    }
}