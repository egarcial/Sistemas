using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistemas.Entidades.Personal_Information;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistemas.Datos.Mapping.Personal_Information_Mapping
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
