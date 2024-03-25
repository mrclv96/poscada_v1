using Microsoft.EntityFrameworkCore;
using System;
using SCADA_A.Entidades.OEE;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SCADA_A.Datos.Mapping.OEE
{
    public class App_ColorsMap : IEntityTypeConfiguration<App_Colors>

    {
        public void Configure(EntityTypeBuilder<App_Colors> builder)
        {
            builder.ToTable("v_App_Colors")
                .HasKey(a => a.ColorID);
        }
    }
}
