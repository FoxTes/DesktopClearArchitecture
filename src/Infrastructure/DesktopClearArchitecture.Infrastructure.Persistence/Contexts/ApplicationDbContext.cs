namespace DesktopClearArchitecture.Infrastructure.Persistence.Contexts;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc />
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Products.
    /// </summary>
    public DbSet<Product> Products { get; set; }
}