using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vivi.Infrastructure.Entities;

namespace Vivi.Dcs.Application;

public static class QueryableExtensions
{
    public static async Task<SearchPage<TResult>> QueryableAsync<TEntity, TResult>(
        this IEfRepository<TEntity> repository,  // 🔹 让调用者传入不同的仓库
        SearchPagedDto search,
        Expression<Func<TEntity, bool>> filterExpression,  // 🔹 让调用者传入筛选条件
        Expression<Func<TEntity, TResult>> selector

    ) where TEntity : EfEntity
    {
        // 🔹 应用筛选条件
        var query = repository
            .Where(filterExpression)
            .OrderByDescending(x => EF.Property<DateTime>(x, "CreatedAt"))  // 🔹 适配不同实体
            .Skip(search.SkipRows())
            .Take(search.pageSize);

        // 🔹 统计总数
        var total = await repository.CountAsync(filterExpression);

        // 🔹 执行查询
        var list = await query.Select(selector).ToArrayAsync();

        return new SearchPage<TResult>(search, list, total);
    }
}