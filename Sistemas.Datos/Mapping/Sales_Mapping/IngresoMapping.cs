using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Purchases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Sales_Mapping
{
    public class IngresoMapping : IEntityTypeConfiguration<Ingreso>
    {
        public void Configure(EntityTypeBuilder<Ingreso> builder)
        {
            builder.ToTable("tbl_Ingreso").
               HasKey(ingreso => ingreso.idIngreso);
            builder
                .Property(ingreso => ingreso.idProveedor);
            builder
                .Property(ingreso => ingreso.idUsuario);
            builder
                .Property(ingreso => ingreso.idTipoComprobante);
            builder
                .Property(ingreso => ingreso.serieComprobante)
                .HasMaxLength(7);
            builder
                .Property(ingreso => ingreso.numComprobante)
                .HasMaxLength(10);
            builder
                .Property(ingreso => ingreso.fechaHora);
            builder
                .Property(ingreso => ingreso.impuesto);
            builder
                .Property(ingreso => ingreso.total);
            builder
                .Property(ingreso => ingreso.idEstado);
        }
    }
}
