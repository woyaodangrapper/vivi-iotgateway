namespace Vivi.Dcs.Contracts.DTOs;

public class SearchPage<T> : SearchPagedDTO
{
    public SearchPage(int pageNo, int pageSize, IReadOnlyList<T> list, int total)
    {
        this.pageIndex = pageNo;
        this.pageSize = pageSize;
        this.total = total;
        this.list = list;
    }

    public SearchPage(SearchPagedDTO search)
        : this(search, default, default)
    {
    }

    public SearchPage(SearchPagedDTO search, IReadOnlyList<T> list, int total)
    : this(search.pageIndex, search.pageSize, list, total)
    {
        this.list = list;
    }

    public int total { get; set; } //总条数
    public IEnumerable<T> list { get; set; }
}