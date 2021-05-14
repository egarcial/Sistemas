using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;

namespace Sistemas.Datos.Mapping.Usuario
{
    public class TelefonoMapping : IEntityTypeConfiguration<Telefono>
    {
        public void Configure(EntityTypeBuilder<Telefono> builder)
        {
            builder.ToTable("tbl_Telefono").
               HasKey(tel => tel.idTelefono);
            builder
                .Property(tel => tel.movil_1)
                .HasMaxLength(11);
            builder
                .Property(tel => tel.movil_2)
                .HasMaxLength(11);
            builder
                .Property(tel => tel.telCasa)
                .HasMaxLength(11);
            builder
                .Property(tel => tel.telOficina)
                .HasMaxLength(11);
        }
    }
}
