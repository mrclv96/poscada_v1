using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    internal class S2019103Map : IEntityTypeConfiguration<S2019103>
    {
        public void Configure(EntityTypeBuilder<S2019103> builder)
        {
            builder.ToTable("TPL_S2019103")
                .HasKey(p => p.id);
        }
    }
}
