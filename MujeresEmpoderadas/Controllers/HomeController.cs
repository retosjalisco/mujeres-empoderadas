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

        public ActionResult Categorias()
        {
            return View();
        }

        public ActionResult BienesYServicios(int? q)
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

        #region LOGIN

        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion([Bind(Include = "CorreoElectronico, Contrasenia")]Login login)
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

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        [Authorize]
        public ActionResult MiPerfil()
        {
            var jefaDeFamilia = db.JefasDeFamilia.Where(x => x.Nombre == "Dulce María").FirstOrDefault();
            return View(jefaDeFamilia);
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Convocatorias()
        {
            var convocatorias = db.Convocatorias;

            return View(convocatorias.ToList());
        }


        #region Bolsa de trabajo

        public ActionResult BolsaDeTrabajo()
        {
            var trabajos = db.Trabajos;

            return View(trabajos.ToList());
        }

        public ActionResult DetalleBolsaDeTrabajo(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var data = db.Trabajos.Find(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        [ChildActionOnly]
        public ActionResult ListaBolsaDeTrabajo()
        {
            var trabajos = db.Trabajos.Take(3);

            return PartialView(trabajos.ToList());
        }

        #endregion

        public ActionResult DetalleConvocatoria(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var data = db.Convocatorias.Find(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        public ActionResult CursosYActividades()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ListaEventos()
        {
            var data = db.Convocatorias.Take(3);

            return PartialView(data.ToList());
        }

        public ActionResult Contactanos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contactanos(Contactanos contacto)
        {
            return RedirectToAction("Gracias");
        }

        public ActionResult Gracias()
        {
            return View();
        }

        public ActionResult PoliticasPrivacidad()
        {
            return View();
        }

        public ActionResult MapaSitio()
        {
            return View();
        }
    }
}