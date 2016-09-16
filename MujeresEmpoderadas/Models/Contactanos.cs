/**
 * Mujeres Empoderadas
 * 
 * Desarrollado por Nicotina Estudio
 * http://www.nicotinaestudio.com - hola@nicotinaestudio.mx
 * 
 * Creado por: Carlos Isaac Hernández Morfín.
 * Fecha de creación: 05/09/2016
 **/
 
using System.ComponentModel.DataAnnotations;

namespace MujeresEmpoderadas.Models
{
    public class Contactanos
    {
        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        [Required()]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Correo electrónico")]
        [Required()]
        public string CorreoElectronico { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Comentarios")]
        [Required()]
        public string Comentarios { get; set; }
    }
}
