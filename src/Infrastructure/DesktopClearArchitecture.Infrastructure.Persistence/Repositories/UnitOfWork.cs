namespace DesktopClearArchitecture.Infrastructure.Persistence.Repositories;

using System.Collections;
using DesktopClearArchitecture.Domain.Abstractions.Repositories;
using Domain.Common;
using Contexts;

/// <inheritdoc />
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    private bool _disposed;
    private Hashtable _repositories;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="dbContext"><see cref="ApplicationDbContext"/>.</param>
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public IGenericRepositoryAsync<TEntity> Repository<TEntity>()
        where TEntity : AuditableEntity
    {
        _repositories ??= new Hashtable();

        var type = typeof(TEntity).Name;
        if (_repositories.ContainsKey(type))
            return (IGenericRepositoryAsync<TEntity>)_repositories[type];

        var repositoryType = typeof(IGenericRepositoryAsync<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

        _repositories.Add(type, repositoryInstance);
        return (IGenericRepositoryAsync<TEntity>)_repositories[type];
    }

    /// <inheritdoc />
    public async Task<int> Commit(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task Rollback()
    {
        _dbContext.ChangeTracker
            .Entries()
            .ToList()
            .ForEach(x => x.Reload());
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     Dispose.
    /// </summary>
    /// <param name="disposing">Is dispose.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                _dbContext.Dispose();
        }

        _disposed = true;
    }
}