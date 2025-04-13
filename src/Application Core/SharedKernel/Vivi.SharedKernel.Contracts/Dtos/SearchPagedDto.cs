namespace Vivi.SharedKernel.Application.Contracts.DTOs;

/// <summary>
/// 查询条件基类
/// </summary>
public abstract class SearchPagedDTO : IDTO
{
    private int _pageNo;
    private int _pageSize;

    /// <summary>
    /// 页码
    /// </summary>
    public int pageIndex
    {
        get => _pageNo < 1 ? 1 : _pageNo;
        set => _pageNo = value;
    }

    /// <summary>
    /// 每页显示条数
    /// </summary>
    public int pageSize
    {
        get
        {
            if (_pageSize < 5) _pageSize = 5;
            if (_pageSize > 100) _pageSize = 100;
            return _pageSize;
        }
        set => _pageSize = value;
    }
}