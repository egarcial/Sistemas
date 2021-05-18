using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Users_Mapping
{
    public class RolMapping : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("tbl_Rol")
               .HasKey(rol => rol.idRol);
            builder
                .Property(rol => rol.nombre)
                .HasMaxLength(30);
            builder
                .Property(rol => rol.descripcion)
                .HasMaxLength(100);
            builder
                .Property(rol => rol.idCondicion);

        }
    }
}
