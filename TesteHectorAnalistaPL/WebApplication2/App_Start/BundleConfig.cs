
using System.Web.Optimization;

namespace WebApplication2.App_Start
{
    public class BundleConfig
    {        
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //cliente
            bundles.Add(new ScriptBundle("~/bundles/controllerJs").Include(
            "~/Scripts/controller/clienteController.js"));

            bundles.Add(new ScriptBundle("~/bundles/behaviorsJs").Include(
            "~/Scripts/behaviors/cliente.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}