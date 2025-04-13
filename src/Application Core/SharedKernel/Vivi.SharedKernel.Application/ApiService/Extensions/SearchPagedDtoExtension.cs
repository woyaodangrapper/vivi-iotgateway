namespace Vivi.SharedKernel.Application.Contracts.DTOs;

public static class SearchPagedDtoExtension
{
    /// <summary>
    /// 计算查询需要跳过的行数
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static int SkipRows(this SearchPagedDTO dto) => (dto.pageIndex - 1) * dto.pageSize;
}