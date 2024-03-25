using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Trace;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.Trace
{
    public class LogTraceMap : IEntityTypeConfiguration<LogTrace>
    {
        public void Configure(EntityTypeBuilder<LogTrace> builder)
        {
            builder.ToTable("LogTrace")
                .HasKey(l => l.DateAndTime);
        }
    }
}
