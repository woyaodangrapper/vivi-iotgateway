namespace Vivi.Dcs.Contracts.DTOs;

public class SearchPage<T> : SearchPagedDto
{
    public SearchPage(int pageNo, int pageSize, IReadOnlyList<T> list, int total)
    {
        this.pageIndex = pageNo;
        this.pageSize = pageSize;
        this.total = total;
        this.list = list;
    }

    public SearchPage(SearchPagedDto search)
        : this(search, default, default)
    {
    }

    public SearchPage(SearchPagedDto search, IReadOnlyList<T> list, int total)
    : this(search.pageIndex, search.pageSize, list, total)
    {
        this.list = list;
    }

    public int total { get; set; } //总条数
    public IEnumerable<T> list { get; set; }
}