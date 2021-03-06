using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Sales_Mapping
{
    public class VentasMapping : IEntityTypeConfiguration<Ventas>
    {
        public void Configure(EntityTypeBuilder<Ventas> builder)
    {

        builder.ToTable("tbl_Ventas").
           HasKey(venta => venta.idVenta);


        builder.HasOne(venta => venta.PersonaCliente)
            .WithOne();

        builder.HasOne(venta => venta.Usuarios)
            .WithOne();
           

        builder.HasOne(venta => venta.Comprobantes)
            .WithOne();

        builder
            .Property(venta => venta.serieComprobante)
            .HasMaxLength(10);

        builder
            .Property(venta => venta.numComprobante)
            .HasMaxLength(10);

        builder
            .Property(venta => venta.fechaHora);

        builder
            .Property(venta => venta.total);

         builder.HasOne(venta => venta.Estados)
            .WithOne();
        }
    }
}
