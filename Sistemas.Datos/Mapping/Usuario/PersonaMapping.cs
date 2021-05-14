using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;

namespace Sistemas.Datos.Mapping.Usuario
{
   public  class PersonaMapping : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("tbl_Persona").
               HasKey(persona => persona.idPersona);
            builder
                .Property(persona => persona.idTipoPersona);
            builder
                .Property(persona => persona.primerNombre)
                .HasMaxLength(50);
            builder
                .Property(persona => persona.segundoNombre)
                .HasMaxLength(50);
            builder
                .Property(persona => persona.apellidoCasada)
                .HasMaxLength(50);
            builder
                .Property(persona => persona.primerApellido)
                .HasMaxLength(50);
            builder
                .Property(persona => persona.segundoApellido)
                .HasMaxLength(50);
            builder
                .Property(persona => persona.idTipoDocumento);
            builder
                .Property(persona => persona.numeroDocumento)
                .HasMaxLength(20);
            builder
                .Property(persona => persona.idDireccion);
            builder
                .Property(persona => persona.idTelefono);
            builder
                .Property(persona => persona.idEmail);
            builder
                .Property(persona => persona.idCondicion);
        }
    }
}
