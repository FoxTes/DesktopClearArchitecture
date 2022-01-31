namespace DesktopClearArchitecture.Infrastructure.Persistence.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesktopClearArchitecture.Domain.Abstractions.Repositories;
using Domain.Common;
using Contexts;
using Microsoft.EntityFrameworkCore;

/// <inheritdoc />
public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T>
    where T : AuditableEntity
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepositoryAsync{T}"/> class.
    /// </summary>
    /// <param name="dbContext"><see cref="ApplicationDbContext"/>.</param>
    public GenericRepositoryAsync(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public IQueryable<T> Entities => _dbContext.Set<T>();

    /// <inheritdoc />
    public async Task<T> AddAsync(T entity)
    {
        await _dbContext
            .Set<T>()
            .AddAsync(entity);
        return entity;
    }

    /// <inheritdoc />
    public Task UpdateAsync(T entity)
    {
        var exist = _dbContext
            .Set<T>()
            .Find(entity.Id);
        _dbContext
            .Entry(exist).CurrentValues
            .SetValues(entity);
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task DeleteAsync(T entity)
    {
        _dbContext
            .Set<T>()
            .Remove(entity);
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbContext
            .Set<T>()
            .FindAsync(id);
    }

    /// <inheritdoc />
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        return await _dbContext
            .Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }
}