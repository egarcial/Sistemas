using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;

namespace Sistemas.Datos.Mapping.Usuario
{
    public class TipoPersonaMapping : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable("tbl_TipoPersona").
              HasKey(tPersona => tPersona.idTipoPersona);
            builder
                .Property(tPersona => tPersona.idTipoPersona)
                .HasMaxLength(50);

        }

    }
}
