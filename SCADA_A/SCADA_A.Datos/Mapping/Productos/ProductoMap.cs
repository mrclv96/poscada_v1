using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCADA_A.Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Text;


namespace SCADA_A.Datos.Mapping.Productos
{
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("producto")
                .HasKey(a => a.idProducto);
        }
    }
}
