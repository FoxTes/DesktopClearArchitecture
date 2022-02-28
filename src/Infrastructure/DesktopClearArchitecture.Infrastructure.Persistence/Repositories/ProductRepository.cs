namespace DesktopClearArchitecture.Infrastructure.Persistence.Repositories;

using Contexts;
using DesktopClearArchitecture.Domain.Abstractions.Repositories;
using Domain.Entities;

/// <inheritdoc cref="DesktopClearArchitecture.Domain.Abstractions.Repositories.IProductRepository" />
public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
{
    /// <inheritdoc />
    public ProductRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
} 