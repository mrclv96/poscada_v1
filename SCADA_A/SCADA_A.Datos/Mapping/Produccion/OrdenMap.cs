using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Produccion;

namespace SCADA_A.Datos.Mapping.Produccion
{
    public class OrdenMap : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("orden")
                .HasKey(a => a.idOrden);
        }
    }
}
