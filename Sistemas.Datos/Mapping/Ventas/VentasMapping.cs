﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Ventas;

namespace Sistemas.Datos.Mapping.Ventas
{
    public class VentasMapping : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {

            builder.ToTable("tbl_Ventas").
               HasKey(venta => venta.idVenta);
            builder
                .Property(venta => venta.idCliente);
            builder
                .Property(venta => venta.idUsuario);
            builder
                .Property(venta => venta.idTipoComprobante);
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
            builder
                .Property(venta => venta.idEstado);
        }
    }
}