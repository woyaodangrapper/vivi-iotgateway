using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class NamingConverterAttribute(FormatEnum value) : Attribute
{
    public FormatEnum EnumValue { get; private set; } = value;
}

public static class NamingConverterStringExtension
{
    /// <summary>
    ///     A string extension method that query if '@this' is null or whiteSpace.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>true if null or whiteSpace, false if not.</returns>
    public static bool IsNullOrWhiteSpace(this string @this) => string.IsNullOrWhiteSpace(@this);

    /// <summary>
    ///     A string extension method that query if '@this' is not null and not whiteSpace.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <returns>false if null or whiteSpace, true if not.</returns>
    public static bool IsNotNullOrWhiteSpace(this string @this) => !string.IsNullOrWhiteSpace(@this);

    public static string ToFormatEnum(this string str, FormatEnum convention)
    {
        return convention switch
        {
            FormatEnum.PascalCase => ToPascalCase(str),
            FormatEnum.CamelCase => ToCamelCase(str),
            FormatEnum.SnakeCase => ToSnakeCase(str),
            FormatEnum.KebabCase => ToKebabCase(str),
            FormatEnum.IsLower => str.ToLower(),
            FormatEnum.IsSkip => str,
            _ => throw new ArgumentException("Invalid naming convention.", nameof(convention)),
        };
    }

    private static string ToPascalCase(string str)
    {
        var words = GetWords(str);
        return string.Join("", words.Select(w => $"{char.ToUpper(w[0])}{w[1..]}"));
    }

    private static string ToCamelCase(string str)
    {
        var words = GetWords(str);
        var firstWord = words.First();
        var otherWords = words.Skip(1);
        var camelCaseWords = otherWords.Select(w => $"{char.ToUpper(w[0])}{w[1..]}");
        return $"{firstWord}{string.Join("", camelCaseWords)}";
    }

    private static string ToSnakeCase(string str)
    {
        var words = GetWords(str);
        return string.Join("_", words).ToLower();
    }

    private static string ToKebabCase(string str)
    {
        var words = GetWords(str);
        return string.Join("-", words).ToLower();
    }

    private static string GetFormatEnum(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return null;
        }

        if (str.ToLower() == str)
        {
            return "lowercase";
        }

        if (str.ToUpper() == str)
        {
            return "UPPERCASE";
        }

        if (str.Contains("-"))
        {
            return "kebab-case";
        }

        if (str.Contains("_"))
        {
            return "snake_case";
        }

        if (char.IsLower(str[0]))
        {
            return "camelCase";
        }

        return "PascalCase";
    }

    private static IEnumerable<string> GetWords(string myString)
    {
        string FormatEnum = GetFormatEnum(myString);

        if (FormatEnum == "camelCase")
        {
            return GetCamelCaseWords(myString);
        }
        else if (FormatEnum == "snake_case")
        {
            return GetSnakeCaseWords(myString);
        }
        else if (FormatEnum == "kebab-case")
        {
            return GetKebabCaseWords(myString);
        }
        else if (FormatEnum == "PascalCase")
        {
            return GetPascalCaseWords(myString);
        }
        else
        {
            return [myString];
            // TODO: 处理无法判断命名规则的情况
        }
    }

    private static IEnumerable<string> GetPascalCaseWords(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            yield break;
        }

        var wordStart = 0;
        for (var i = 1; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]) && !char.IsUpper(str[i - 1]))
            {
                yield return str.Substring(wordStart, i - wordStart);
                wordStart = i;
            }
            else if (char.IsUpper(str[i]) && i < str.Length - 1 && !char.IsUpper(str[i + 1]))
            {
                yield return str.Substring(wordStart, i - wordStart);
                wordStart = i;
            }
            else if (i == str.Length - 1)
            {
                yield return str.Substring(wordStart);
            }
        }
    }

    private static IEnumerable<string> GetCamelCaseWords(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            yield break;
        }

        var wordStart = 0;
        for (var i = 1; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]) && !char.IsUpper(str[i - 1]))
            {
                yield return str.Substring(wordStart, i - wordStart);
                wordStart = i;
            }
            else if (char.IsUpper(str[i]) && i < str.Length - 1 && !char.IsUpper(str[i + 1]))
            {
                yield return str.Substring(wordStart, i - wordStart + 1);
                wordStart = i + 1;
            }
            else if (i == str.Length - 1)
            {
                yield return str.Substring(wordStart);
            }
        }
    }

    private static IEnumerable<string> GetSnakeCaseWords(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            yield break;
        }

        var wordStart = 0;
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i] == '_')
            {
                yield return str.Substring(wordStart, i - wordStart);
                wordStart = i + 1;
            }
            else if (i == str.Length - 1)
            {
                yield return str.Substring(wordStart);
            }
        }
    }

    private static IEnumerable<string> GetKebabCaseWords(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            yield break;
        }

        var wordStart = 0;
        for (var i = 0; i < str.Length; i++)
        {
            if (str[i] == '-')
            {
                yield return str.Substring(wordStart, i - wordStart);
                wordStart = i + 1;
            }
            else if (i == str.Length - 1)
            {
                yield return str.Substring(wordStart);
            }
        }
    }
}

public static class ModelBuilderExtensions
{
    /// <summary>
    /// 批量应用 MapEntityAsColumn 方法，格式化所有实体的列名
    /// </summary>
    /// <param name="modelBuilder">ModelBuilder 实例</param>
    /// <param name="formatEnum">命名格式</param>
    public static void ApplyColumnNamingConvention(this ModelBuilder modelBuilder, FormatEnum formatEnum = FormatEnum.SnakeCase)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            if (clrType == null) continue;

            var method = typeof(ModelBuilderExtensions)
                .GetMethod(nameof(MapEntityAsColumn), BindingFlags.Static | BindingFlags.Public)?
                .MakeGenericMethod(clrType);

            var entityMethod = typeof(ModelBuilder).GetMethod("Entity", Type.EmptyTypes)
            ?.MakeGenericMethod(clrType);
            method?.Invoke(null, [entityMethod?.Invoke(modelBuilder, null), formatEnum]);
        }
    }

    /// <summary>
    /// 将实体的属性映射到数据库列名，按照指定的命名格式
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <param name="entityTypeBuilder">实体类型构建器</param>
    /// <param name="formatEnum">命名格式</param>
    public static void MapEntityAsColumn<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, FormatEnum formatEnum = FormatEnum.SnakeCase)
        where TEntity : class
    {
        var uniqueProperties = typeof(TEntity)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .GroupBy(property => property.Name)
            .Where(group => group.Count() == 1 || group.Any(property => property.DeclaringType == typeof(TEntity)))
            .Select(group => group.First())
            .ToArray();

        foreach (var property in uniqueProperties)
        {
            if (Attribute.IsDefined(property, typeof(NotMappedAttribute)))
            {
                continue;
            }
            var propertyName = property.Name;

            var fieldName = propertyName.ToFormatEnum(property.GetCustomAttribute<NamingConverterAttribute>()?.EnumValue ?? formatEnum);
            entityTypeBuilder.Property(property.PropertyType, propertyName).HasColumnName(fieldName);
        }
    }
}


public enum FormatEnum
{
    PascalCase,
    CamelCase,
    SnakeCase,
    KebabCase,
    IsLower,
    IsSkip
}