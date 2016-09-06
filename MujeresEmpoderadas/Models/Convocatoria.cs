using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MujeresEmpoderadas.Models
{
    [Table("Convocatorias")]
    public class Convocatoria
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ConvocatoriaId { get; set; }

        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public string Titulo { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeFinalizacion { get; set; }

        [DataType(DataType.Text)]
        [StringLength(15)]
        [Display(Name = "Fotografía")]
        public string Foto { get; set; }
    }
}
