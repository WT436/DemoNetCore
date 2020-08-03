using B7_ConnectDataBase.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B7_ConnectDataBase.Models.TypeConfiguration
{
    public class XaType : IEntityTypeConfiguration<Xa>
    {
        public void Configure(EntityTypeBuilder<Xa> builder)
        {
            builder.HasKey(e => e.Idpx)
                    .HasName("PK__Xa__B87C5B795B3F6E1E");

            builder.Property(e => e.Idpx)
                .HasColumnName("IDPX")
                .ValueGeneratedNever();

            builder.Property(e => e.Cap).HasMaxLength(30);

            builder.Property(e => e.Idqh).HasColumnName("IDQH");

            builder.Property(e => e.NameXa).HasMaxLength(300);

            builder.HasOne(d => d.IdqhNavigation)
                .WithMany(p => p.Xa)
                .HasForeignKey(d => d.Idqh)
                .HasConstraintName("FK__Xa__IDQH__29572725");
        }
    }
}
