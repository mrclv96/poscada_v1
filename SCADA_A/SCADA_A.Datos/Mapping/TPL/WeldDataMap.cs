using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class WeldDataMap : IEntityTypeConfiguration<WeldData>
    {
        public void Configure(EntityTypeBuilder<WeldData> builder)
        {
            builder.ToTable("TPL_WeldData")
                .HasKey(p => p.id);
        }
    }
}
