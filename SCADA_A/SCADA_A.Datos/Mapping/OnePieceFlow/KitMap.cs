using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.OnePieceFlow;

namespace SCADA_A.Datos.Mapping.OnePieceFlow
{
    public class KitMap : IEntityTypeConfiguration<Kit>
    {
        public void Configure(EntityTypeBuilder<Kit> builder)
        {
            builder.ToTable("kit")
                .HasKey(k => k.idKit);
        }
    }
}
