using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class TorqueDataMap : IEntityTypeConfiguration<TorqueData>
    {
        public void Configure(EntityTypeBuilder<TorqueData> builder)
        {
            builder.ToTable("TPL_TorqueData")
                .HasKey(p => p.id);
        }
    }
}
