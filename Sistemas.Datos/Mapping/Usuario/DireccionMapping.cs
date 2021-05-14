using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;


namespace Sistemas.Datos.Mapping.Usuario
{
    public class DireccionMapping : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("direccion").
               HasKey(direccion => direccion.idDireccion);
            builder
                .Property(direccion => direccion.idMunicipio);
            builder
                .Property(direccion => direccion.nombreCalle)
                .HasMaxLength(50);
            builder
                .Property(direccion => direccion.numeroCalle);
            builder
                .Property(direccion => direccion.avenida)
                .HasMaxLength(50);
            builder
                .Property(direccion => direccion.barrio)
                .HasMaxLength(50);
            builder
                .Property(direccion => direccion.zona);
            builder
                .Property(direccion => direccion.numeroCasa);
            builder.
                Property(direccion => direccion.referencia)
                .HasMaxLength(50);


        }
    }
}
