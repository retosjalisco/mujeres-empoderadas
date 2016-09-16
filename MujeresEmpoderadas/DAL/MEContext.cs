/**
 * Mujeres Empoderadas
 * 
 * Desarrollado por Nicotina Estudio
 * http://www.nicotinaestudio.com - hola@nicotinaestudio.mx
 * 
 * Creado por: Carlos Isaac Hernández Morfín.
 * Fecha de creación: 05/09/2016
 **/
 
using MujeresEmpoderadas.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MujeresEmpoderadas.DAL
{
    class MEContext : DbContext
    {
        public DbSet<Convocatoria> Convocatorias { get; set; }
        public DbSet<JefaDeFamilia> JefasDeFamilia { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}