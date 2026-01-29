using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Core.Model;

namespace MyShop.Api.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.ToTable("AM7_Category");
        
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");
        
    }
}