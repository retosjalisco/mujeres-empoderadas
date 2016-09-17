/**
* Mujeres Empoderadas
* 
* Desarrollado por Nicotina Estudio
* http://www.nicotinaestudio.com - hola@nicotinaestudio.mx
* 
* Creado por: Carlos Isaac Hernández Morfín.
* Fecha de creación: 16/09/2016
**/

using System.ComponentModel.DataAnnotations;

namespace MujeresEmpoderadas.Models
{
    public class SMS
    {
        [DataType(DataType.Text)]
        [StringLength(250)]
        [Display(Name = "Mensaje")]
        [Required()]
        public string Mensaje { get; set; }
    }
}