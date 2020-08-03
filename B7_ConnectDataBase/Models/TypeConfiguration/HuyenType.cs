using B7_ConnectDataBase.Models.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B7_ConnectDataBase.Models.TypeConfiguration
{
    public class HuyenType : IEntityTypeConfiguration<Huyen>
    {
        public void Configure(EntityTypeBuilder<Huyen> builder)
        {
            builder.HasKey(e => e.Idqh)
                    .HasName("PK__Huyen__B87C32EAB8D5B201");

            builder.Property(e => e.Idqh)
                .HasColumnName("IDQH")
                .ValueGeneratedNever();

            builder.Property(e => e.Idtp).HasColumnName("IDTP");

            builder.Property(e => e.NameQh)
                .HasColumnName("NameQH")
                .HasMaxLength(300);

            builder.HasOne(d => d.IdtpNavigation)
                .WithMany(p => p.Huyen)
                .HasForeignKey(d => d.Idtp)
                .HasConstraintName("FK__Huyen__IDTP__267ABA7A");
        }
    }
}
