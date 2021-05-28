using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Purchases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Purchases_Mapping
{
    class IngresoMapping : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder)
        {

            builder.ToTable("tbl_Ingreso").
                HasKey(ingreso => ingreso.idIngreso);

            builder.HasOne(ingreso => ingreso.PersonaProveedor)
                .WithOne();

            builder.HasOne(ingreso => ingreso.Usuarios)
                 .WithOne();

            builder.HasOne(ingreso => ingreso.Comprobantes)
                 .WithOne();
           
            builder
                .Property(ingreso => ingreso.serieComprobante);

            builder
                .Property(ingreso => ingreso.numComprobante);

            builder
                .Property(ingreso => ingreso.fechaHora);

            builder
                .Property(ingreso => ingreso.impuesto);

            builder
                .Property(ingreso => ingreso.total);

            builder.HasOne(ingreso => ingreso.Estados)
              .WithOne();

        }
    }
}
