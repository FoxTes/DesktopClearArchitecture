namespace DesktopClearArchitecture.Domain.Common.Result;

using Abstractions.Repositories;

/// <summary>
/// Provides the implementation of the <see cref="IPagedList{T}"/> and converter.
/// </summary>
/// <typeparam name="TSource">The type of the source.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
public record PagedList<TSource, TResult> : IPagedList<TResult>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{TSource, TResult}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="converter">The converter.</param>
    /// <param name="pageIndex">The index of the page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="indexFrom">The index from.</param>
    public PagedList(
            IEnumerable<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
            int pageIndex,
            int pageSize,
            int indexFrom)
    {
        if (indexFrom > pageIndex)
        {
            throw new ArgumentException(
                $"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
        }

        if (source is IQueryable<TSource> queryable)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = queryable.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var items = queryable
                .Skip((PageIndex - IndexFrom) * PageSize)
                .Take(PageSize)
                .ToArray();

            Items = new List<TResult>(converter(items));
        }
        else
        {
            var enumerable = source as TSource[] ?? source.ToArray();

            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = enumerable.Length;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var items = enumerable
                .Skip((PageIndex - IndexFrom) * PageSize)
                .Take(PageSize)
                .ToArray();

            Items = new List<TResult>(converter(items));
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{TSource, TResult}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="converter">The converter.</param>
    public PagedList(IPagedList<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
    {
        PageIndex = source.PageIndex;
        PageSize = source.PageSize;
        IndexFrom = source.IndexFrom;
        TotalCount = source.TotalCount;
        TotalPages = source.TotalPages;

        Items = new List<TResult>(converter(source.Items));
    }

    /// <inheritdoc/>
    public int PageIndex { get; }

    /// <inheritdoc/>
    public int PageSize { get; }

    /// <inheritdoc/>
    public int TotalCount { get; }

    /// <inheritdoc/>
    public int TotalPages { get; }

    /// <inheritdoc/>
    public int IndexFrom { get; }

    /// <inheritdoc/>
    public IList<TResult> Items { get; }

    /// <inheritdoc/>
    public bool HasPreviousPage => PageIndex - IndexFrom > 0;

    /// <inheritdoc/>
    public bool HasNextPage => PageIndex - IndexFrom + 1 < TotalPages;

    /// <summary>
    /// Creates an empty of <see cref="IPagedList{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type for paging.</typeparam>
    /// <returns>An empty instance of <see cref="IPagedList{T}"/>.</returns>
    public static IPagedList<T> Empty<T>() => new PagedList<T>();
}

/// <summary>
/// Represents the default implementation of the <see cref="IPagedList{T}"/> interface.
/// </summary>
/// <typeparam name="T">The type of the data to page.</typeparam>
public record PagedList<T> : IPagedList<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{T}" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="pageIndex">The index of the page.</param>
    /// <param name="pageSize">The size of the page.</param>
    /// <param name="indexFrom">The index from.</param>
    public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom)
    {
        if (indexFrom > pageIndex)
        {
            throw new ArgumentException(
                $"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
        }

        if (source is IQueryable<T> queryable)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = queryable.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            Items = queryable
                .Skip((PageIndex - IndexFrom) * PageSize)
                .Take(PageSize)
                .ToList();
        }
        else
        {
            var enumerable = source.ToList();

            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = enumerable.Count;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            Items = enumerable
                .Skip((PageIndex - IndexFrom) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{T}" /> class.
    /// </summary>
    public PagedList() => Items = Array.Empty<T>();

    /// <inheritdoc />
    public int PageIndex { get; init; }

    /// <inheritdoc />
    public int PageSize { get; init; }

    /// <inheritdoc />
    public int TotalCount { get; init; }

    /// <inheritdoc />
    public int TotalPages { get; init; }

    /// <inheritdoc />
    public int IndexFrom { get; init; }

    /// <inheritdoc />
    public IList<T> Items { get; init; }

    /// <inheritdoc />
    public bool HasPreviousPage => PageIndex - IndexFrom > 0;

    /// <inheritdoc />
    public bool HasNextPage => PageIndex - IndexFrom + 1 < TotalPages;

    /// <summary>
    /// Creates a new instance of <see cref="IPagedList{TResult}"/> from source of <see cref="IPagedList{TSource}"/> instance.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <param name="source">The source.</param>
    /// <param name="converter">The converter.</param>
    /// <returns>An instance of <see cref="IPagedList{TResult}"/>.</returns>
    public static IPagedList<TResult> From<TResult, TSource>(
        IPagedList<TSource> source,
        Func<IEnumerable<TSource>, IEnumerable<TResult>> converter) =>
        new PagedList<TSource, TResult>(source, converter);
}