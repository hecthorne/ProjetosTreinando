using System;
using System.Web.Optimization;
using WebApplication2.App_Start;

namespace WebApplication2
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
        }
    }
}