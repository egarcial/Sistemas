using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.WareHouse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.WareHouse_Mapping
{
    public class ArticuloMapping : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder<Articulo> builder)
        {
            builder.ToTable("tbl_Articulo").HasKey(articulo => articulo.idArticulo);

            builder.Property(articulo => articulo.codigo)
                .HasMaxLength(50);

            builder.Property(articulo => articulo.nombre)
                .HasMaxLength(50);

            builder.Property(articulo => articulo.precioVenta);

            builder.Property(articulo => articulo.stock);

            builder.Property(articulo => articulo.descripcion)
                .HasMaxLength(256);

            //relaciones entre entidades
            builder.HasOne(articulo => articulo.Categorias)
               .WithOne();

            builder.HasOne(articulo => articulo.Condiciones)
               .WithOne();


        }
    }
}
