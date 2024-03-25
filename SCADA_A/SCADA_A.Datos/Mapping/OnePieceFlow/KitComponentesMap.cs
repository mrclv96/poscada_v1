using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.OnePieceFlow;

namespace SCADA_A.Datos.Mapping.OnePieceFlow
{
    public class KitComponentesMap : IEntityTypeConfiguration<KitComponentes>
    {
        public void Configure(EntityTypeBuilder<KitComponentes> builder)
        {
            builder.ToTable("kitcomponentes")
                .HasKey(c => c.idKitComponentes);
        }
    }
}
