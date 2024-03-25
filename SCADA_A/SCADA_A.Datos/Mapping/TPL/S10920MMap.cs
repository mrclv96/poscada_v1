using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class S10920MMap : IEntityTypeConfiguration<S10920M>
    {
        public void Configure(EntityTypeBuilder<S10920M> builder)
        {
            builder.ToTable("TPL_S10920M")
                .HasKey(p => p.id);
        }
    }
}
