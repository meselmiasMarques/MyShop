using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Core.Model;

namespace MyShop.Api.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
       builder.ToTable("AM7_Product");
       
       builder.HasKey(p => p.Id);
       
       builder.Property(c => c.Id)
           .ValueGeneratedOnAdd()
           .UseIdentityColumn(1, 1);
       
       builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");
       
       builder.Property(p => p.Description)
           .HasMaxLength(250)
           .HasColumnType("varchar(250)");
       
       builder.Property(p => p.Price)
           .IsRequired()
           .HasColumnType("decimal(18,2)");
       
       builder.Property(p => p.ImageUrl)
           .HasMaxLength(250)
           .HasColumnType("varchar(250)");
       
       builder.HasOne(p => p.Category)
           .WithMany(c => c.Products)
           .HasForeignKey(p => p.CategoryId)
           .HasConstraintName("FK_AM7_Product_CategoryId")
           .OnDelete(DeleteBehavior.Cascade);
    }
}