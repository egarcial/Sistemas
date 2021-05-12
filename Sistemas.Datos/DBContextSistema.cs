using Microsoft.EntityFrameworkCore;
using Sistemas.Datos.Mapping.Almacen;

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
            
            modelBuilder.ApplyConfiguration(new CategoriaMapping());//referencia a la clase CategoriaMapping

        }
    }
}
