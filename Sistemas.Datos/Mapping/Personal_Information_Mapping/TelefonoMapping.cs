using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Personal_Information;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Personal_Information_Mapping
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

