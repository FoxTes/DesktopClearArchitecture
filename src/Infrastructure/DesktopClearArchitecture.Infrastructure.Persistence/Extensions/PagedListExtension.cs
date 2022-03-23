namespace DesktopClearArchitecture.Infrastructure.Persistence.Extensions;

using DesktopClearArchitecture.Domain.Abstractions.Repositories;
using Domain.Common.Result;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Provides some extension methods for <see cref="IEnumerable{T}" /> to provide paging capability.
/// </summary>
public static class PagedListExtension
{
    /// <summary>
    /// Converts the specified source to <see cref="IPagedList{T}" />
    /// by the specified <paramref name="pageIndex" /> and <paramref name="pageSize" />.
    /// </summary>
    /// <typeparam name="T">The type of the source.</typeparam>
    /// <param name="source">The source to paging.</param>
    /// <param name="pageIndex">The index of the page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="indexFrom">The start index value.</param>
    /// <returns>An instance of the inherited from <see cref="IPagedList{T}" /> interface.</returns>
    public static IPagedList<T> ToPagedList<T>(
        this IEnumerable<T> source,
        int pageIndex,
        int pageSize,
        int indexFrom = 0)
    {
        return new PagedList<T>(source, pageIndex, pageSize, indexFrom);
    }

    /// <summary>
    /// Converts the specified source to <see cref="IPagedList{T}" />
    /// by the specified <paramref name="converter" />, <paramref name="pageIndex" /> and <paramref name="pageSize" />.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="source">The source to convert.</param>
    /// <param name="converter">
    /// The converter to change the <typeparamref name="TSource" /> to <typeparamref name="TResult" />.
    /// </param>
    /// <param name="pageIndex">The page index.</param>
    /// <param name="pageSize">The page size.</param>
    /// <param name="indexFrom">The start index value.</param>
    /// <returns>An instance of the inherited from <see cref="IPagedList{T}" /> interface.</returns>
    public static IPagedList<TResult> ToPagedList<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
        int pageIndex,
        int pageSize,
        int indexFrom = 0)
    {
        return new PagedList<TSource, TResult>(source, converter, pageIndex, pageSize, indexFrom);
    }

    /// <summary>
    /// Converts the specified source to <see cref="IPagedList{T}" />
    /// by the specified <paramref name="pageIndex" /> and <paramref name="pageSize" />.
    /// </summary>
    /// <typeparam name="T">The type of the source.</typeparam>
    /// <param name="source">The source to paging.</param>
    /// <param name="pageIndex">The index of the page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="indexFrom">The start index value.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
    /// </param>
    /// <returns>An instance of the inherited from <see cref="IPagedList{T}" /> interface.</returns>
    public static async Task<IPagedList<T>> ToPagedListAsync<T>(
        this IQueryable<T> source,
        int pageIndex,
        int pageSize,
        int indexFrom = 0,
        CancellationToken cancellationToken = default)
    {
        if (indexFrom > pageIndex)
        {
            throw new ArgumentException(
                $"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
        }

        var count = await source
            .CountAsync(cancellationToken)
            .ConfigureAwait(false);
        var items = await source
            .Skip((pageIndex - indexFrom) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);

        var pagedList = new PagedList<T>
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            IndexFrom = indexFrom,
            TotalCount = count,
            Items = items,
            TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        };

        return pagedList;
    }
}