using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Users_Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Entidades.Users.Usuario>
    {
        public void Configure(EntityTypeBuilder<Entidades.Users.Usuario> builder)
        {
            builder.ToTable("tbl_Usuario").
              HasKey(usuario => usuario.idUsuario);

            builder.HasOne(usuario => usuario.Roles)
                .WithOne();

            builder
                .Property(usuario => usuario.primerNombre)
                .HasMaxLength(100);

            builder
                .Property(usuario => usuario.segundoNombre)
                .HasMaxLength(50);

            builder
                .Property(usuario => usuario.apellidoCasada)
                .HasMaxLength(50);

            builder
                .Property(usuario => usuario.primerApellido)
                .HasMaxLength(50);

            builder
                .Property(usuario => usuario.segundoApellido)
                .HasMaxLength(50);


            builder.HasOne(usuario => usuario.Documentos)
                .WithOne();

            builder
                .Property(usuario => usuario.numeroDocumento)
                .HasMaxLength(20);


            builder.HasOne(usuario => usuario.Direcciones)
                .WithOne();


            builder.HasOne(usuario => usuario.Telefonos)
                .WithOne();


            builder.HasOne(usuario => usuario.Emails)
                .WithOne();


            builder
                .Property(usuario => usuario.passwordHash);

            builder
                .Property(usuario => usuario.passwordSalt)
                .HasMaxLength(64);


            builder.HasOne(usuario => usuario.Condiciones)
                .WithOne();

        }
    }
}
