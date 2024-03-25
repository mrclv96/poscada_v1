using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.OEE;

namespace SCADA_A.Datos.Mapping.OEE
{
    public class App_TypesMap : IEntityTypeConfiguration<App_Types>
    {
        public void Configure(EntityTypeBuilder<App_Types> builder)
        {
            builder.ToTable("v_App_Types")
                .HasKey(a => a.TypeID);
        }
    }
}
