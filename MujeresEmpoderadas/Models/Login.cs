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
    public class Login
    {
        [DataType(DataType.EmailAddress)]
        [StringLength(128)]
        [Required()]
        [Display(Name = "Correo electrónico")]
        public string CorreoElectronico { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required()]
        public string Contrasenia { get; set; }
    }
}