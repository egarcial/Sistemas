using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Purchases;
using Sistemas.Entidades.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Purchases_Mapping
{
    class DetalleIngresoMapping : IEntityTypeConfiguration<DetalleIngreso>
    {
        public void Configure(EntityTypeBuilder<DetalleIngreso> builder)
        {

            builder.ToTable("tbl_DetalleIngreso").
               HasKey(detIngreso => detIngreso.idDetalleIngreso);
            builder
                .Property(detIngreso => detIngreso.idingreso);
            builder
                .Property(detIngreso => detIngreso.idArticulo);
            builder
                .Property(detIngreso => detIngreso.cantidad);
            builder
                .Property(detIngreso => detIngreso.precioDetalle);

        }
    }
}
