using Microsoft.EntityFrameworkCore;

namespace TreasureCache.Abstractions.Paging;

public class PagedList<T>
{
    private PagedList(List<T> items, int page, int pageSize,  int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }

    public List<T> Items { get; set; } 
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public bool HasPreviousPage => Page > 1;
    public bool HasNextPage => PageSize * Page < TotalCount;

    public static async Task<PagedList<T>> ToPagedList(IQueryable<T> query, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var totalCount = await query
            .CountAsync(cancellationToken);
        
        // Excluding borderline cases for page and pageSize
        page = Math.Max(1, Math.Min(page, (int)Math.Ceiling((double)totalCount / pageSize)));
        
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken); 
        
        return new PagedList<T>(items, page, pageSize, totalCount);
    }
}