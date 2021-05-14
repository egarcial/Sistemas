using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;

namespace Sistemas.Datos.Mapping.Usuario
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
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
                .Property(usuario => usuario.numDocumento)
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
