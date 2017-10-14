using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            ViewBag.Message = "Your contact page.";

            if (usuario.Login == "hector")
            {
                FormsAuthentication.SetAuthCookie(usuario.Login, false);
                return View("~/Views/Home/Logado.cshtml");
            }
            else
            {
                //RedirectToAction("Index");
                return RedirectToAction("Index", "Home");
            }            
        }

        public ActionResult Deslogar()
        {
            FormsAuthentication.SignOut();

            return View();
        }

        [Authorize]
        public ActionResult Logado()
        {
            return View();
        }
    }
}