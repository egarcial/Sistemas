using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Sales_Mapping
{
    public class DetalleVentaMapping : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.ToTable("tbl_DetalleVenta").
               HasKey(detVenta => detVenta.idDetalleVenta);
            builder
                .Property(detVenta => detVenta.idVenta);
            builder
                .Property(detVenta => detVenta.idVenta);
            builder
                .Property(detVenta => detVenta.idArticulo);
            builder
                .Property(detVenta => detVenta.cantidad);
            builder
                .Property(detVenta => detVenta.precioDetalleVenta);
            builder
                .Property(detVenta => detVenta.descuento);
        }
    }
}
