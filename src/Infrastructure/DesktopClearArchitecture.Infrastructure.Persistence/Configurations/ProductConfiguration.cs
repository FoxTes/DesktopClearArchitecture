namespace DesktopClearArchitecture.Infrastructure.Persistence.Configurations
{
    using Bogus;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <inheritdoc />
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(s => s.Name);

            var ids = 1;
            var stock = new Faker<Product>()
                .RuleFor(m => m.Id, _ => ids++)
                .RuleFor(m => m.Name, f => f.Commerce.ProductName());
            builder.HasData(stock.GenerateBetween(10, 100));
        }
    }
}