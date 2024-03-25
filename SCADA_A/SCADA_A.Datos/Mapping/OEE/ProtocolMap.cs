using Microsoft.EntityFrameworkCore;
using System;
using SCADA_A.Entidades.OEE;

namespace SCADA_A.Datos.Mapping.OEE
{
    public class ProtocolMap : IEntityTypeConfiguration<Protocol>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Protocol> builder)
        {
            builder.ToView("Protocol")
                .HasKey(p => p.idProtocol);
        }
    }
}
