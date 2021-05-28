using Microsoft.EntityFrameworkCore;
using Sistemas.Datos.Mapping.Conditions_Mapping;
using Sistemas.Datos.Mapping.Documents_Mapping;
using Sistemas.Datos.Mapping.Personal_Information_Mapping;
using Sistemas.Datos.Mapping.Persons_Mapping;
using Sistemas.Datos.Mapping.Purchases_Mapping;
using Sistemas.Datos.Mapping.Sales_Mapping;
using Sistemas.Datos.Mapping.Users_Mapping;
using Sistemas.Datos.Mapping.WareHouse_Mapping;
using Sistemas.Entidades.Conditions;
using Sistemas.Entidades.Documents;
using Sistemas.Entidades.Personal_Information;
using Sistemas.Entidades.Persons;
using Sistemas.Entidades.Purchases;
using Sistemas.Entidades.Sales;
using Sistemas.Entidades.Users;
using Sistemas.Entidades.WareHouse;

namespace Sistemas.Datos
{
    /* DBContext es un metodo que nos permite conectar con la 
    base de datos SQL*/
    public class DBContextSistema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<Rol> Rols { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<DetalleVenta> DetalleVentas { get; set; }

        public DbSet<Ventas> Vts { get; set; }

        public DbSet<DetalleIngreso> DetalleIngresos { get; set; }

        public DbSet<Ingreso> Ingresos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<TipoPersona> TipoPersonas { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<Municipio> Municipios { get; set; }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<Comprobante> Comprobante { get; set; }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Condicion> Condiciones { get; set; }
          
        public DbSet<Estado> Estados { get; set; }

        /*traendo todas las opciones que nos permitan utilizar
         el dbcontext para poder hacer conexion con la base de datos*/
        public DBContextSistema(DbContextOptions<DBContextSistema> options) : base(options)
        {

        }
        /*nos ayudara a trabajar con los modelos*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //comenzamos a usar los modelos que tenemos en la capa entidades
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration
                (new CategoriaMapping());//referencia a la clase CategoriaMapping

            modelBuilder.ApplyConfiguration
                (new ArticuloMapping());

            modelBuilder.ApplyConfiguration
                (new ComprobanteMapping());

            modelBuilder.ApplyConfiguration
                (new CondicionMapping());

            modelBuilder.ApplyConfiguration
                (new DepartamentoMapping());

            modelBuilder.ApplyConfiguration
                (new DetalleIngresoMapping());

            modelBuilder.ApplyConfiguration
                (new DetalleVentaMapping());

            modelBuilder.ApplyConfiguration
                (new DireccionMapping());

            modelBuilder.ApplyConfiguration
                (new DocumentoMapping());

            modelBuilder.ApplyConfiguration
                (new EmailMapping());

            modelBuilder.ApplyConfiguration
                (new EstadoMapping());
            
            modelBuilder.ApplyConfiguration
                (new IngresoMapping());

            modelBuilder.ApplyConfiguration
                (new MunicipioMapping());

            modelBuilder.ApplyConfiguration
                (new PersonaMapping());

            modelBuilder.ApplyConfiguration
                (new RolMapping());

            modelBuilder.ApplyConfiguration
                (new TelefonoMapping());

            modelBuilder.ApplyConfiguration
                (new TipoPersonaMapping());

            modelBuilder.ApplyConfiguration
                (new UsuarioMapping());

            modelBuilder.ApplyConfiguration
                (new VentasMapping());

        }
    }
}
