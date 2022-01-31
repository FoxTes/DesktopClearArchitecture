namespace DesktopClearArchitecture.Domain.Abstractions.Repositories;

using Common;

/// <summary>
/// Unit of work.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Get repository.
    /// </summary>
    IGenericRepositoryAsync<T> Repository<T>()
        where T : AuditableEntity;

    /// <summary>
    /// Commit.
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
    /// <returns></returns>
    Task<int> Commit(CancellationToken cancellationToken);

    /// <summary>
    /// Rollback.
    /// </summary>
    Task Rollback();
}