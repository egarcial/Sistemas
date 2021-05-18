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
            builder
                .Property(usuario => usuario.idRol);
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
            builder
                .Property(usuario => usuario.idTipoDocumento);
            builder
                .Property(usuario => usuario.numeroDocumento)
                .HasMaxLength(20);
            builder
                .Property(usuario => usuario.idDireccion);
            builder
                .Property(usuario => usuario.idTelefono);
            builder
                .Property(usuario => usuario.idEmail);
            builder
                .Property(usuario => usuario.passwordHash);
            builder
                .Property(usuario => usuario.passwordSalt)
                .HasMaxLength(64);
            builder
                .Property(usuario => usuario.idCondicion)
                .HasMaxLength(64);

        }
    }
}
