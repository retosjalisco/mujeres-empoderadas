using MujeresEmpoderadas.DAL;
using MujeresEmpoderadas.Models;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace MujeresEmpoderadas.Controllers
{
    public class HomeController : Controller
    {
        private MEContext db = new MEContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BienesYServicios()
        {
            var jefasdeFamilia = db.JefasDeFamilia;
            return View(jefasdeFamilia.ToList());
        }

        #region PREINSCRIPCION
        public ActionResult PreInscripcion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PreInscripcion([Bind(Include = "Region, Nombre, PrimerApellido, SegundoApellido, Calle, NoExterior, NoInterior, Colonia, EntreLasCalles, Municipio, Localidad, CP, NacimEstado, NacimMunicipio, NacimFecha, TelefonoFijo, TelefonoMovil, CorreoElectronico, Contrasena, Escolaridad, EstadoCivil, Genero")]JefaDeFamilia jefaDeFamilia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Valida que el usuario no esté registrado
                    var usuarioExistente = db.JefasDeFamilia.Where(x => x.CorreoElectronico == jefaDeFamilia.CorreoElectronico).FirstOrDefault();

                    if (usuarioExistente != null)
                    {
                        ModelState.AddModelError("", "Ese correo electrónico ya ha sido registrado anteriormente.");
                        return View();
                    }

                    var hoy = DateTime.Now;

                    jefaDeFamilia.FechaDeRegistro = hoy;
                    jefaDeFamilia.NacimFecha = hoy;
                    jefaDeFamilia.Contrasena = Utilidades.encriptarContrasena(jefaDeFamilia.Contrasena);
                    jefaDeFamilia.Negocio = new Negocio { Nombre = ""};

                    db.JefasDeFamilia.Add(jefaDeFamilia);
                    db.SaveChanges();

                    FormsAuthentication.SetAuthCookie(jefaDeFamilia.CorreoElectronico, false);
                    return RedirectToAction("MiPerfil", "JefasDeFamilia");
                }
            }
            catch(Exception ex)
            {
                Utilidades.Log(ex.ToString());
                ModelState.AddModelError("", "No se han podido guardar los cambio. Intente más tarde y si el problemas persiste contacte al administrador del sistema. ERROR: " + ex.ToString());
            }
            return View();
        }
        #endregion

        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion([Bind(Include = "CorreoElectronico, Contrasena")]Login login)
        {
            if (ModelState.IsValid)
            {
                if (JefaDeFamilia.esValido(login.CorreoElectronico, Utilidades.encriptarContrasena(login.Contrasenia)))
                {
                    FormsAuthentication.SetAuthCookie(login.CorreoElectronico, false);
                    return RedirectToAction("MiPerfil", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Datos de acceso incorrectos");
                }
            }
            return View(login);
        }

        [Authorize]
        public ActionResult MiPerfil()
        {
            return View();
        }

        [Authorize]
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Convocatorias()
        {
            var convocatorias = db.Convocatorias;

            return View(convocatorias.ToList());
        }

        public ActionResult DetalleConvocatoria(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var data = db.Convocatorias.Find(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        [Authorize]
        public ActionResult BolsaDeTrabajo()
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