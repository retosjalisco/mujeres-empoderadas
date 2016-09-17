/**
 * Mujeres Empoderadas
 * 
 * Desarrollado por Nicotina Estudio
 * http://www.nicotinaestudio.com - hola@nicotinaestudio.mx
 * 
 * Creado por: Carlos Isaac Hernández Morfín.
 * Fecha de creación: 05/09/2016
 **/

using MujeresEmpoderadas.DAL;
using MujeresEmpoderadas.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Twilio;

namespace MujeresEmpoderadas.Controllers
{
    public class AdminController : Controller
    {
        private MEContext db = new MEContext();
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

        public ActionResult Index()
        {
            //if (!Request.IsAuthenticated)
            //    return RedirectToAction("Login", "Admin");

            //Valida admin
            //if (!Utilidades.esAdmin(User.Identity.GetUserName()))
            //    return RedirectToAction("Login", "Admin");

            return View();
        }

        public ActionResult Beneficiarias()
        {
            var jefasDeFamilia = db.JefasDeFamilia;
            return View(jefasDeFamilia.ToList());
        }

        public ActionResult DetalleBeneficiarias(int? id)
        {
            var jefaDeFamiia = db.JefasDeFamilia.Find(id);
            return View(jefaDeFamiia);
        }

        public ActionResult EnviarSMS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarSMS(SMS sms)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                //TODO: Enviar SMS Twilio
                string AccountSid = "ACabc613041a9c936f847565f3c37fdbe1";
                string AuthToken = "45c8f2c931bace2a48aa4f6313cac137";

                var twilio = new TwilioRestClient(AccountSid, AuthToken);

                var message = twilio.SendMessage(
                    "+12016769431", "+524433632200",
                    sms.Mensaje
                );
            }
            catch (Exception ex) {

                Utilidades.Log(ex.Message);
            }

            return RedirectToAction("EnviarSMSEnviado");
        }

        public ActionResult EnviarSMSEnviado()
        {
            return View();
        }
    }
}