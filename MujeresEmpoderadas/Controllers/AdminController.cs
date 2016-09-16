using Microsoft.AspNet.Identity;
using MujeresEmpoderadas.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace MujeresEmpoderadas.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (login.CorreoElectronico == "admin@mujeresempoderadas.com" && login.Contrasenia == "admME@2016")
                {
                    FormsAuthentication.SetAuthCookie(login.CorreoElectronico, false);
                    return RedirectToAction("index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Datos de acceso incorrectos");
                }
            }
            return View(login);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }

        [Authorize]
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("Login", "Admin");

            // Valida admin
            if (!Utilidades.esAdmin(User.Identity.GetUserName()))
                return RedirectToAction("Login", "Admin");

            return View();
        }
    }
}