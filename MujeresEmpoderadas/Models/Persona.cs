using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MujeresEmpoderadas.Models
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PersonaId { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        public Genero Genero { get; set; }

        public int Edad { get; set; }

        public Parentesco Parentesco { get; set; }
        public Ocupacion Ocupacion { get; set; }
        public Escolaridad Escolaridad { get; set; }
        public bool EscolaridadEsCompleto { get; set; }
    }
}
