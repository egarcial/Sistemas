using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Persons_Mapping
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
