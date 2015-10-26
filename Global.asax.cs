using System;
using System.Web;

namespace SS
{
    public class Global : HttpApplication
    {
        //Initialize your application singleton
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }
    }
}