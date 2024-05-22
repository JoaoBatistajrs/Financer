using FinancialManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialManager.InfraStructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ExpenseTypeId).IsRequired();

            builder.HasOne(x => x.Type)
                   .WithMany()
                   .HasForeignKey(x => x.ExpenseTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Registers)
                   .WithOne(r => r.Category)
                   .HasForeignKey(r => r.CategoryId);
        }
    }
}
