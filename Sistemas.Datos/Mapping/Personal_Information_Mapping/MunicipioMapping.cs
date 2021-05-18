using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Personal_Information;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Personal_Information_Mapping
{
    public class MunicipioMapping : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("tbl_Municipio").
               HasKey(municipio => municipio.idMunicipio);
            builder
                .Property(municipio => municipio.nombreMunicipio)
                .HasMaxLength(70);
            builder
                .Property(municipio => municipio.idDepartamento);
        }
    }
}
