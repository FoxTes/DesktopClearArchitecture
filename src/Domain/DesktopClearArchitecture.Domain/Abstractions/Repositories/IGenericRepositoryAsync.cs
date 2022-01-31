namespace DesktopClearArchitecture.Domain.Abstractions.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// A service for working with entities.
/// </summary>
public interface IGenericRepositoryAsync<T>
    where T : class
{
    /// <summary>
    /// Get entitle.
    /// </summary>
    IQueryable<T> Entities { get; }

    /// <summary>
    /// Get by id.
    /// </summary>
    /// <param name="id">Id.</param>
    Task<T> GetByIdAsync(long id);

    /// <summary>
    /// Get all.
    /// </summary>
    Task<List<T>> GetAllAsync();

    /// <summary>
    /// Get paged response.
    /// </summary>
    /// <param name="pageNumber">Pane number.</param>
    /// <param name="pageSize">Page size.</param>
    Task<List<T>> GetPagedResponseAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="entity">Entity.</param>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Update.
    /// </summary>
    /// <param name="entity">Entity.</param>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Delete.
    /// </summary>
    /// <param name="entity">Entity.</param>
    Task DeleteAsync(T entity);
}