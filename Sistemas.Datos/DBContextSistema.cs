using Microsoft.EntityFrameworkCore;
using Sistemas.Datos.Mapping.Almacen;
using Sistemas.Datos.Mapping.Ventas;
using Sistemas.Datos.Mapping.Usuario;

namespace Sistemas.Datos
{
    /* DBContext es un metodo que nos permite conectar con la 
    base de datos SQL*/
    public class DBContextSistema : DbContext
    {
        /*traendo todas las opciones que nos permitan utilizar
         el dbcontext para poder hacer conexion con la base de datos*/
        public DBContextSistema(DbContextOptions<DBContextSistema> options) 
            : base(options)
        {

        }
        /*nos ayudara a trabajar con los modelos*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   //comenzamos a usar los modelos que tenemos en la capa entidades
            base.OnModelCreating(modelBuilder);
            
            modelBuilder
                .ApplyConfiguration(new CategoriaMapping());//referencia a la clase CategoriaMapping
            modelBuilder
                .ApplyConfiguration(new ArticuloMapping());
            modelBuilder
                .ApplyConfiguration(new ComprobanteMapping());
            modelBuilder
                .ApplyConfiguration(new CondicionMapping());
            modelBuilder
                .ApplyConfiguration(new DepartamentoMapping());
            modelBuilder
                .ApplyConfiguration(new DetalleIngresoMapping());
            modelBuilder
                .ApplyConfiguration(new DetalleVentaMapping());
            modelBuilder
               .ApplyConfiguration(new DireccionMapping());
            modelBuilder
               .ApplyConfiguration(new DocumentoMapping());
            modelBuilder
               .ApplyConfiguration(new EmailMapping());
            modelBuilder
               .ApplyConfiguration(new EstadoMapping());
            modelBuilder
               .ApplyConfiguration(new IngresoMapping());
            modelBuilder
               .ApplyConfiguration(new MunicipioMapping());
            modelBuilder
             .ApplyConfiguration(new PersonaMapping());
            modelBuilder
             .ApplyConfiguration(new RolMapping());
            modelBuilder
             .ApplyConfiguration(new TelefonoMapping());
            modelBuilder
             .ApplyConfiguration(new TipoPersonaMapping());
            modelBuilder
             .ApplyConfiguration(new UsuarioMapping());
            modelBuilder
            .ApplyConfiguration(new VentasMapping());

        }
    }
}
