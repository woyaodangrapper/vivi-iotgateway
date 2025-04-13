using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vivi.Infrastructure.Entities;

namespace Vivi.Dcs.Application;

public static class QueryableExtensions
{
    public static async Task<SearchPage<TResult>> QueryableAsync<TEntity, TResult>(
        this IEfRepository<TEntity> repository,  // 🔹 让调用者传入不同的仓库
        SearchPagedDTO search,
        Expression<Func<TEntity, bool>> filterExpression,  // 🔹 让调用者传入筛选条件
        Expression<Func<TEntity, TResult>> selector,
         bool orderByCreatedAtDesc = true
    ) where TEntity : EfEntity
    {
        // 🔹 应用筛选条件
        var query = repository.Where(filterExpression);

        // 🔹 根据参数决定是否排序
        // 🔹 条件排序（字段存在并允许排序）
        if (orderByCreatedAtDesc && HasCreatedAtProperty<TEntity>())
        {
            query = query.OrderByDescending(x => EF.Property<DateTime>(x, "CreatedAt"));
        }

        // 🔹 分页处理
        query = query
            .Skip(search.SkipRows())
            .Take(search.pageSize);

        // 🔹 统计总数
        var total = await repository.CountAsync(filterExpression);

        // 🔹 执行查询
        var list = await query.Select(selector).ToArrayAsync();
        return new SearchPage<TResult>(search, list, total);
    }
    // 🔍 检查是否包含 CreatedAt 属性
    private static bool HasCreatedAtProperty<T>()
    {
        return typeof(T).GetProperty("CreatedAt", BindingFlags.Public | BindingFlags.Instance) != null;
    }
}