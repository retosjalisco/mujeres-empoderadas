namespace MujeresEmpoderadas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Convocatorias",
                c => new
                    {
                        ConvocatoriaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 200),
                        Descripcion = c.String(),
                        FechaDeInicio = c.DateTime(nullable: false),
                        FechaDeFinalizacion = c.DateTime(nullable: false),
                        Foto = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ConvocatoriaId);
            
            CreateTable(
                "dbo.JefasDeFamilia",
                c => new
                    {
                        JefaDeFamiliaId = c.Int(nullable: false, identity: true),
                        FechaDeRegistro = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                        EsBloqueadoChat = c.Boolean(nullable: false),
                        EsBeneficiario = c.Boolean(nullable: false),
                        Region = c.Int(nullable: false),
                        HistoriaDeVida = c.String(),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        PrimerApellido = c.String(nullable: false, maxLength: 50),
                        SegundoApellido = c.String(nullable: false, maxLength: 50),
                        Calle = c.String(maxLength: 50),
                        NoExterior = c.String(maxLength: 10),
                        NoInterior = c.String(maxLength: 5),
                        Colonia = c.String(maxLength: 50),
                        EntreLasCalles = c.String(maxLength: 200),
                        Municipio = c.String(maxLength: 50),
                        Localidad = c.String(maxLength: 50),
                        CP = c.String(maxLength: 5),
                        NacimEstado = c.String(maxLength: 50),
                        NacimMunicipio = c.String(maxLength: 50),
                        NacimFecha = c.DateTime(nullable: false),
                        TelefonoFijo = c.String(maxLength: 14),
                        TelefonoMovil = c.String(maxLength: 14),
                        CorreoElectronico = c.String(nullable: false, maxLength: 100),
                        Contrasena = c.String(nullable: false),
                        Escolaridad = c.Int(nullable: false),
                        EstadoCivil = c.Int(nullable: false),
                        Genero = c.Int(nullable: false),
                        EsMexicano = c.Boolean(nullable: false),
                        IdentidadOtro = c.String(maxLength: 100),
                        CURP = c.String(maxLength: 18),
                        IFE = c.String(maxLength: 18),
                        Pasaporte = c.String(maxLength: 18),
                        EsIndigena = c.Boolean(nullable: false),
                        ComunidadOrigen = c.String(maxLength: 50),
                        HablaDialectoIndigena = c.Boolean(nullable: false),
                        QueDialectoHabla = c.String(maxLength: 50),
                        NoPersonasVivenVivienda = c.Int(nullable: false),
                        NoDormitoriosVivienda = c.Int(nullable: false),
                        EsDiscapacitado = c.Boolean(nullable: false),
                        Discapacidad = c.Int(nullable: false),
                        DiscapacidadMotivo = c.Int(nullable: false),
                        AcreditaDiscapacidad = c.Boolean(nullable: false),
                        MotivoNoAcreditaDiscapacidad = c.String(maxLength: 50),
                        InstanciaAcreditaDiscapacidad = c.String(maxLength: 100),
                        NegocioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JefaDeFamiliaId)
                .ForeignKey("dbo.Negocios", t => t.NegocioId)
                .Index(t => t.NegocioId);
            
            CreateTable(
                "dbo.Negocios",
                c => new
                    {
                        NegocioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
                        Latitud = c.String(maxLength: 15),
                        Longitud = c.String(maxLength: 15),
                        Estado = c.String(maxLength: 50),
                        Municipio = c.String(maxLength: 50),
                        Localidad = c.String(maxLength: 50),
                        Telefono = c.String(maxLength: 14),
                        Calle = c.String(maxLength: 50),
                        Colonia = c.String(maxLength: 50),
                        NoExterior = c.String(maxLength: 5),
                        NoInterior = c.String(maxLength: 5),
                        CategoriaNegocio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NegocioId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                        PrimerApellido = c.String(maxLength: 50),
                        SegundoApellido = c.String(maxLength: 50),
                        Genero = c.Int(nullable: false),
                        Edad = c.Int(nullable: false),
                        Parentesco = c.Int(nullable: false),
                        Ocupacion = c.Int(nullable: false),
                        Escolaridad = c.Int(nullable: false),
                        EscolaridadEsCompleto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.Trabajos",
                c => new
                    {
                        TrabajoId = c.Int(nullable: false, identity: true),
                        EsActivo = c.Boolean(nullable: false),
                        FechaDePublicacion = c.DateTime(nullable: false),
                        Titulo = c.String(maxLength: 200),
                        Descripcion = c.String(maxLength: 1500),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContactoNombre = c.String(maxLength: 50),
                        ContactoTelefono = c.String(maxLength: 14),
                        ContactoCorreoElectronico = c.String(maxLength: 100),
                        ContactoEmpresa = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.TrabajoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JefasDeFamilia", "NegocioId", "dbo.Negocios");
            DropIndex("dbo.JefasDeFamilia", new[] { "NegocioId" });
            DropTable("dbo.Trabajos");
            DropTable("dbo.Personas");
            DropTable("dbo.Negocios");
            DropTable("dbo.JefasDeFamilia");
            DropTable("dbo.Convocatorias");
        }
    }
}
