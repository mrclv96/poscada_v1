using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class S10924MMap : IEntityTypeConfiguration<S10924M>
    {
        public void Configure(EntityTypeBuilder<S10924M> builder)
        {
            builder.ToTable("TPL_S10924M")
                .HasKey(p => p.id);
        }
    }
}
