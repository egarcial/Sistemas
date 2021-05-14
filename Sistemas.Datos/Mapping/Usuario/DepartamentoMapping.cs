using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;

namespace Sistemas.Datos.Mapping.Usuario
{
    class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
    {

        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("condicion")
                .HasKey(departamento => departamento.idDepatamento);
            builder.Property(departamento => departamento.nombreDepartamento)
                .HasMaxLength(50);

        }
    }
}
