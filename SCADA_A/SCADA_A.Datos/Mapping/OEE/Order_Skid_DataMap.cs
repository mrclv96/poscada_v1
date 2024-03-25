using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.OEE;

namespace SCADA_A.Datos.Mapping.OEE
{
    public class Order_Skid_DataMap : IEntityTypeConfiguration<Order_Skid_Data>
    {
        public void Configure(EntityTypeBuilder<Order_Skid_Data> builder)
        {
            builder.ToTable("v_Order_Skid_Data")
                .HasKey(o => o.DateTimeIn);
        }
    }
}
