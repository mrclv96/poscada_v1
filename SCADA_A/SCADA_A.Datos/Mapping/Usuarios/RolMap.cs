using Microsoft.EntityFrameworkCore;
using SCADA_A.Entidades.Usuarios;
using System;


namespace SCADA_A.Datos.Mapping.Usuarios
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol")
                    .HasKey(r => r.IdRol);
        }
    }
}
