using System.ComponentModel.DataAnnotations;

namespace MujeresEmpoderadas.Models
{
    public enum Parentesco { Casa, Edificio };
    public enum Ocupacion { Casa, Edificio };
    public enum Escolaridad { Ninguna, Primaria, Secundaria, Bachillerato, Técnica, Superior };
    public enum TipoNegocio { Casa, Edificio };
    public enum Genero { Mujer, Hombre };
    public enum Discapacidad { Casa, Edificio };
    public enum DiscapacidadMotivo { Casa, Edificio };
    public enum InstanciaAcreditaDiscapacidad { Casa, Edificio };
    public enum EstadoCivil { Soltera, Casada, Viuda,
        [Display(Name = "Union libre")]
        UnionLibre, Divorciada, Separada };

    public enum Region { Norte,
        [Display(Name = "Altos Norte")]
        AltosNorte,
        [Display(Name = "Altos Sur")]
        AltosSur,
        [Display(Name = "Ciénega")]
        Cienega, Sureste, Sur,
        [Display(Name = "Sierra de Amula")]
        SierraDeAmula,
        [Display(Name = "Costa Sur")]
        CostaSur,
        [Display(Name = "Costa-Sierra Occidental")]
        CostaSierraOccidental, Valles, Lagunas, Centro };

    public enum CategoriaNegocio {
        Esteticas,
        Tortilleria,
        [Display(Name = "Cocina económica")]
        CocinaEconómica,
        Abarrotes,
        Restaurante
    };
}
