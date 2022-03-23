#nullable enable

namespace DesktopClearArchitecture.Infrastructure.Persistence.Repositories;

using DesktopClearArchitecture.Domain.Abstractions.Repositories;
using Domain.Common.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

/// <summary>
/// Represents the default implementation of the <see cref="T:IUnitOfWork"/> and <see cref="T:IUnitOfWork{TContext}"/> interface.
/// </summary>
/// <typeparam name="TContext">The type of the db context.</typeparam>
public sealed class UnitOfWork<TContext> : IRepositoryFactory, IUnitOfWork<TContext>
    where TContext : DbContext
{
    private bool _disposed;
    private Dictionary<Type, object>? _repositories;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    public UnitOfWork(TContext context)
    {
        DbContext = context ?? throw new ArgumentNullException(nameof(context));
        LastSaveChangesResult = new SaveChangesResult();
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="UnitOfWork{TContext}"/> class.
    /// </summary>
    ~UnitOfWork() => Dispose(false);

    /// <inheritdoc />
    public TContext DbContext { get; }

    /// <inheritdoc />
    public SaveChangesResult LastSaveChangesResult { get; }

    /// <inheritdoc />
    public Task<IDbContextTransaction> BeginTransactionAsync(bool useIfExists = false)
    {
        var transaction = DbContext.Database.CurrentTransaction;
        if (transaction == null)
            return DbContext.Database.BeginTransactionAsync();

        return useIfExists ? Task.FromResult(transaction) : DbContext.Database.BeginTransactionAsync();
    }

    /// <inheritdoc />
    public IDbContextTransaction BeginTransaction(bool useIfExists = false)
    {
        var transaction = DbContext.Database.CurrentTransaction;
        if (transaction == null)
            return DbContext.Database.BeginTransaction();

        return useIfExists ? transaction : DbContext.Database.BeginTransaction();
    }

    /// <inheritdoc />
    public void SetAutoDetectChanges(bool value) => DbContext.ChangeTracker.AutoDetectChangesEnabled = value;

    /// <inheritdoc cref="IUnitOfWork.GetRepository{TEntity}" />
    public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false)
        where TEntity : class
    {
        _repositories ??= new Dictionary<Type, object>();

        if (hasCustomRepository)
        {
            var customRepo = DbContext.GetService<IRepository<TEntity>>();
            if (customRepo != null)
                return customRepo;
        }

        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
            _repositories[type] = new Repository<TEntity>(DbContext);

        return (IRepository<TEntity>)_repositories[type];
    }

    /// <inheritdoc />
    public int ExecuteSqlCommand(string sql, params object[] parameters) =>
        DbContext.Database.ExecuteSqlRaw(sql, parameters);

    /// <inheritdoc />
    public Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters) =>
        DbContext.Database.ExecuteSqlRawAsync(sql, parameters);

    /// <inheritdoc />
    public IQueryable<TEntity> FromSqlRaw<TEntity>(string sql, params object[] parameters)
        where TEntity : class
        => DbContext.Set<TEntity>().FromSqlRaw(sql, parameters);

    /// <inheritdoc />
    public int SaveChanges()
    {
        try
        {
            return DbContext.SaveChanges();
        }
        catch (Exception exception)
        {
            LastSaveChangesResult.Exception = exception;
            return 0;
        }
    }

    /// <inheritdoc />
    public async Task<int> SaveChangesAsync()
    {
        try
        {
            return await DbContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            LastSaveChangesResult.Exception = exception;
            return 0;
        }
    }

    /// <inheritdoc />
    public async Task<int> SaveChangesAsync(params IUnitOfWork[] unitOfWorks)
    {
        var count = 0;
        foreach (var unitOfWork in unitOfWorks)
            count += await unitOfWork.SaveChangesAsync();

        count += await SaveChangesAsync();
        return count;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc />
    public void TrackGraph(object rootEntity, Action<EntityEntryGraphNode> callback) =>
        DbContext.ChangeTracker.TrackGraph(rootEntity, callback);

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _repositories?.Clear();
                DbContext.Dispose();
            }
        }

        _disposed = true;
    }
}