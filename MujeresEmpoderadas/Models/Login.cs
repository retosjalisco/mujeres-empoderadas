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