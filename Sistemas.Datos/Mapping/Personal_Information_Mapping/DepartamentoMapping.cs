using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Personal_Information;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Personal_Information_Mapping
{
    class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
    {

        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("tbl_Departamento")
                .HasKey(departamento => departamento.idDepatamento);
            builder.Property(departamento => departamento.nombreDepartamento)
                .HasMaxLength(50);

        }
    }
}
