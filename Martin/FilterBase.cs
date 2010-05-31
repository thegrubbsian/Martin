using System;
using System.Web.Routing;

namespace Martin {

    public class FilterBase : Attribute, IFilter, IContextAware {

        public RequestContext Context { get; set; }
        public virtual void BeforeExecute() {}
        public virtual void AfterExecute() {}

        public T ValueOf<T>(string hashKey) {
            return ValueProvider.ValueOf<T>(Context, hashKey);
        }
    }
}