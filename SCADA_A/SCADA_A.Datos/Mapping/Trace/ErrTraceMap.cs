using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Trace;
using System;


namespace SCADA_A.Datos.Mapping.Trace
{
    public class ErrTraceMap : IEntityTypeConfiguration<ErrTrace>
    {
        public void Configure(EntityTypeBuilder<ErrTrace> builder)
        {
            builder.ToTable("ErrTrace")
                .HasKey(e => e.DateAndTime);
        }
    }
}
