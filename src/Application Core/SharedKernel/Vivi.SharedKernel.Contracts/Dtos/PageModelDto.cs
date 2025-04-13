namespace Vivi.SharedKernel.Application.Contracts.DTOs;

[Serializable]
public class PageModelDTO<T> : IDTO
{
    private IReadOnlyList<T> _data = Array.Empty<T>();

    public PageModelDTO()
    {
    }

    public PageModelDTO(SearchPagedDTO search)
        : this(search, default, default)
    {
    }

    public PageModelDTO(SearchPagedDTO search, IReadOnlyList<T> data, int count, dynamic xData = null)
        : this(search.pageIndex, search.pageSize, data, count)
    {
        this.XData = xData;
    }

    public PageModelDTO(int pageIndex, int pageSize, IReadOnlyList<T> data, int count, dynamic xData = null)
    {
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
        this.TotalCount = count;
        this.Data = data;
        this.XData = xData;
    }

    public IReadOnlyList<T> Data
    {
        get => _data;
        set => _data = value ?? Array.Empty<T>();
    }

    public int RowsCount => _data.Count;

    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public int PageCount => (this.RowsCount + this.PageSize - 1) / this.PageSize;

    public dynamic XData { get; set; }
}