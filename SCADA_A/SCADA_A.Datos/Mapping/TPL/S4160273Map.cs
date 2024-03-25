using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    internal class S4160273Map : IEntityTypeConfiguration<S4160273>
    {
        public void Configure(EntityTypeBuilder<S4160273> builder)
        {
            builder.ToTable("TPL_4160273")
                .HasKey(p => p.id);
        }
    }
}
