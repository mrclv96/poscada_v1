using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Produccion;

namespace SCADA_A.Datos.Mapping.Produccion
{
    public class ProtocoloMap : IEntityTypeConfiguration<Protocolo>
    {
        public void Configure(EntityTypeBuilder<Protocolo> builder)
        {
            builder.ToTable("protocolo")
                .HasKey(p => p.idProtocolo);
        }
    }
}
