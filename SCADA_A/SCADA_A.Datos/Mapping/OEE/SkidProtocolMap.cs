using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Entidades.OEE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Datos.Mapping.OEE
{
    public class SkidProtocolMap : IEntityTypeConfiguration<SkidProtocol>
    {
        public void Configure(EntityTypeBuilder<SkidProtocol> builder)
        {
            builder.ToTable("SkidProtocol")
                .HasKey(p => p.ProtID);
        }
    }
}
