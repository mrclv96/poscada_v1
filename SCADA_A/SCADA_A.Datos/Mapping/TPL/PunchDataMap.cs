using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.TPL;

namespace SCADA_A.Datos.Mapping.TPL
{
    public class PunchDataMap : IEntityTypeConfiguration<PunchData>
    {
        public void Configure(EntityTypeBuilder<PunchData> builder)
        {
            builder.ToTable("TPL_PunchData")
                .HasKey(p => p.id);
        }
    }
}
