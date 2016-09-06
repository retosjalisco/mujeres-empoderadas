using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MujeresEmpoderadas.Models
{
    [Table("Negocios")]
    public class Negocio
    {
        [Key]
        [ScaffoldColumn(false)]
        public int NegocioId { get; set; }

        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [DataType(DataType.Text)]
        [StringLength(15)]
        [Display(Name = "Latitud")]
        public string Latitud { get; set; }

        [DataType(DataType.Text)]
        [StringLength(15)]
        [Display(Name = "Longitud")]
        public string Longitud { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Municipio")]
        public string Municipio { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [DataType(DataType.Text)]
        [StringLength(14)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [DataType(DataType.Text)]
        [StringLength(5)]
        [Display(Name = "Número exterior")]
        public string NoExterior { get; set; }

        [DataType(DataType.Text)]
        [StringLength(5)]
        [Display(Name = "Número interior")]
        public string NoInterior { get; set; }

        public CategoriaNegocio CategoriaNegocio { get; set; }
    }
}