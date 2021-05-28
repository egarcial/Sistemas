using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Personal_Information;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Personal_Information_Mapping
{
    public class DireccionMapping : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("tbl_Direccion").
               HasKey(direccion => direccion.idDireccion);

            builder.HasOne(direccion => direccion.Municipios)
               .WithOne();

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
