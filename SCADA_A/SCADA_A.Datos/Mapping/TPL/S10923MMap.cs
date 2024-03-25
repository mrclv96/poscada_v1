using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class S10923MMap : IEntityTypeConfiguration<S10923M>
    {
        public void Configure(EntityTypeBuilder<S10923M> builder)
        {
            builder.ToTable("TPL_S10923M")
                .HasKey(p => p.id);
        }
    }
}
