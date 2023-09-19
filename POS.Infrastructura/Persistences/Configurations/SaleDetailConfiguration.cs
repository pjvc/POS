using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;

namespace POS.Infrastructura.Persistences.Configurations
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SaleDetail> builder)
        {
            builder.HasKey(e => e.SaleDetailId).HasName("PK__SaleDeta__70DB14FE004B2923");

            builder.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SaleDetai__Produ__6A30C649");

            builder.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SaleDetai__SaleI__6B24EA82");
        }
    }
}
