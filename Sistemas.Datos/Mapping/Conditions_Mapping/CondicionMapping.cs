using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Conditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Conditions_Mapping
{
    public class CondicionMapping : IEntityTypeConfiguration<Condicion>
    {
        public void Configure(EntityTypeBuilder<Condicion> builder)
        {
            builder.ToTable("tbl_Condicion").
                HasKey(condicion => condicion.idCondicion);

            builder.Property(condicion => condicion.condicion);

        }
    }
}
