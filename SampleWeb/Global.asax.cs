using System;
using Martin;

namespace SampleWeb {

    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            Config.AddAction<DateAction>("API/CurrentDate");
        }
    }
}