using System.Web.Mvc;

namespace MujeresEmpoderadas.Controllers
{
    public class JefasDeFamiliaController : Controller
    {
        public ActionResult MiPerfil()
        {
            return View();
        }

        [Authorize]
        public ActionResult Chat()
        {
            return View();
        }

        [Authorize]
        public ActionResult Convocatorias()
        {
            return View();
        }

        [Authorize]
        public ActionResult BolsaDeTrabajo()
        {
            return View();
        }

        [Authorize]
        public ActionResult BienesYServicios()
        {
            return View();
        }

        [Authorize]
        public ActionResult CursosYActividades()
        {
            return View();
        }

        [Authorize]
        public ActionResult Contactanos()
        {
            return View();
        }
    }
}