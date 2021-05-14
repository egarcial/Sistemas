using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Usuarios;

namespace Sistemas.Datos.Mapping.Usuario
{
    public class EmailMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("tbl_Email").
               HasKey(email => email.idEmail);
            builder
                .Property(email => email.emailPersonal);
            builder
                .Property(email => email.emailLaboral);
        }
    }
}
