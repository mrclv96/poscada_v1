using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class ScanDataMap : IEntityTypeConfiguration<ScanData>
    {
        public void Configure(EntityTypeBuilder<ScanData> builder)
        {
            builder.ToTable("TPL_ScanData")
                .HasKey(p => p.id);
        }
    }
}
