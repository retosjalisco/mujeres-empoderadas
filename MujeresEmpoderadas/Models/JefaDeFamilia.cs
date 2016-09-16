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
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;

namespace MujeresEmpoderadas.Models
{
    [Table("JefasDeFamilia")]
    public class JefaDeFamilia
    {
        [Key]
        [ScaffoldColumn(false)]
        public int JefaDeFamiliaId { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime FechaDeRegistro { get; set; }

        [ScaffoldColumn(false)]
        public bool EsActivo { get; set; }

        [ScaffoldColumn(false)]
        public bool EsBloqueadoChat { get; set; }

        [ScaffoldColumn(false)]
        public bool EsBeneficiario { get; set; }

        public Region Region { get; set; }

        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string HistoriaDeVida { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        [Required()]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Primer apellido")]
        [Required()]
        public string PrimerApellido { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Segundo apellido")]
        [Required()]
        public string SegundoApellido { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Calle o Avenida")]
        public string Calle { get; set; }

        [DataType(DataType.Text)]
        [StringLength(10)]
        [Display(Name = "No. Exterior")]
        public string NoExterior { get; set; }

        [DataType(DataType.Text)]
        [StringLength(5)]
        [Display(Name = "No. Interior")]
        public string NoInterior { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Entre las calles")]
        public string EntreLasCalles { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Municipio")]
        public string Municipio { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [DataType(DataType.Text)]
        [StringLength(5)]
        [Display(Name = "C.P.")]
        public string CP { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string NacimEstado { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Municipio")]
        public string NacimMunicipio { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime NacimFecha { get; set; }

        [DataType(DataType.Text)]
        [StringLength(14)]
        [Display(Name = "Teléfono fijo")]
        public string TelefonoFijo { get; set; }

        [DataType(DataType.Text)]
        [StringLength(14)]
        [Display(Name = "Teléfono móvil")]
        public string TelefonoMovil { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Correo electrónico de contacto")]
        [Required()]
        public string CorreoElectronico { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required()]
        public string Contrasena { get; set; }

        [Display(Name = "Escolaridad")]
        public Escolaridad Escolaridad { get; set; }

        [Display(Name = "Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }

        [Display(Name = "Sexo")]
        public Genero Genero { get; set; }
        public bool EsMexicano { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Otro")]
        public string IdentidadOtro { get; set; }

        [DataType(DataType.Text)]
        [StringLength(18)]
        [Display(Name = "CURP")]
        public string CURP { get; set; }

        [DataType(DataType.Text)]
        [StringLength(18)]
        [Display(Name = "IFE")]
        public string IFE { get; set; }

        [DataType(DataType.Text)]
        [StringLength(18)]
        [Display(Name = "Pasaporte")]
        public string Pasaporte { get; set; }

        public bool EsIndigena { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Comunidad de origen")]
        public string ComunidadOrigen { get; set; }

        public bool HablaDialectoIndigena { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Que dialecto habla")]
        public string QueDialectoHabla { get; set; }
        public int NoPersonasVivenVivienda { get; set; }
        public int NoDormitoriosVivienda { get; set; }
        public bool EsDiscapacitado { get; set; }
        public Discapacidad Discapacidad { get; set; }
        public DiscapacidadMotivo DiscapacidadMotivo { get; set; }
        public bool AcreditaDiscapacidad { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Motivo")]
        public string MotivoNoAcreditaDiscapacidad { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Instancia")]
        public string InstanciaAcreditaDiscapacidad { get; set; }

        public int NegocioId { get; set; }
        public virtual Negocio Negocio { get; set; }


        public JefaDeFamilia() { }

        public static bool esValido(string correoElectronico, string Contrasena)
        {
            MEContext db = new MEContext();

            var data = db.JefasDeFamilia.Where(x => x.CorreoElectronico == correoElectronico
            && x.Contrasena == Contrasena);

            if (data.Count() > 0)
                return true;

            return false;
        }
    }
}
