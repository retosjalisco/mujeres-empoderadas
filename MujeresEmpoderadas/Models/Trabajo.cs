/**
 * Mujeres Empoderadas
 * 
 * Desarrollado por Nicotina Estudio
 * http://www.nicotinaestudio.com - hola@nicotinaestudio.mx
 * 
 * Creado por: Carlos Isaac Hernández Morfín.
 * Fecha de creación: 05/09/2016
 **/
 
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MujeresEmpoderadas.Models
{
    [Table("Trabajos")]
    public class Trabajo
    {
        [Key]
        [ScaffoldColumn(false)]
        public int TrabajoId { get; set; }

        public bool EsActivo { get; set; }
        public DateTime FechaDePublicacion { get; set; }

        [DataType(DataType.Text)]
        [StringLength(200)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [DataType(DataType.Text)]
        [StringLength(1500)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Salario")]
        public decimal Salario { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string ContactoNombre { get; set; }

        [DataType(DataType.Text)]
        [StringLength(14)]
        [Display(Name = "Teléfono")]
        public string ContactoTelefono { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Correo electrónico")]
        public string ContactoCorreoElectronico { get; set; }

        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Empresa")]
        public string ContactoEmpresa { get; set; }
    }
}
