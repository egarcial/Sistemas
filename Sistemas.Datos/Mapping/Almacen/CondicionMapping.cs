using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Almacen;


namespace Sistemas.Datos.Mapping.Almacen
{
    public class CondicionMapping : IEntityTypeConfiguration<Condicion>
    {
        public void Configure(EntityTypeBuilder<Condicion> builder)
        {
            builder.ToTable("condicion").
                HasKey(condicion => condicion.idCondicion);
            builder.Property(condicion => condicion.condicion);

        }
    }
}
