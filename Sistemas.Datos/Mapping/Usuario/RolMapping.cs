using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;

namespace Sistemas.Datos.Mapping.Usuario
{
    public class RolMapping : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("detalleIngreso")
               .HasKey(rol => rol.idRol);
            builder
                .Property(rol => rol.nombre)
                .HasMaxLength(30);
            builder
                .Property(rol => rol.descripcion)
                .HasMaxLength(100);
            builder
                .Property(rol => rol.idCondicion);

        }
    }
}
