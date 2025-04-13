using FluentValidation.Validators;
using Swashbuckle.AspNetCore.SwaggerGen;
using Vivi.SharedKernel.Application.Extensions;

namespace Vivi.SharedKernel.Application.FluentValidation;

public class FluentValidationSchemaFilter : ISchemaFilter
{
    private readonly IValidatorRegistry _validatorRegistry;
    public FluentValidationSchemaFilter(IValidatorRegistry validatorRegistry)
    {
        _validatorRegistry = validatorRegistry;
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var validator = _validatorRegistry.GetValidator(context.Type);

        if (validator == null) return;

        var validationContext = new ValidationContext<object>(Activator.CreateInstance(context.Type)!);
        var validationRules = validator.CreateDescriptor().Rules;

        foreach (var rule in validationRules)
        {
            var propertyName = rule.PropertyName;
            if (!schema.Properties.ContainsKey(propertyName)) continue;

            var propertySchema = schema.Properties[propertyName];

            foreach (var component in rule.Components)
            {
                var validatorMetadata = component.Validator;

                // 1️⃣ 处理 NotNullValidator（不允许为 null）
                if (validatorMetadata is INotNullValidator)
                {
                    schema.Required.Add(propertyName);
                }

                // 2️⃣ 处理 NotEmptyValidator（不能为空字符串）
                if (validatorMetadata is INotEmptyValidator)
                {
                    schema.Required.Add(propertyName);
                }

                // 3️⃣ 处理 ILengthValidator（长度、最小长度、最大长度、精确长度）
                if (validatorMetadata is ILengthValidator lengthValidator)
                {
                    if (lengthValidator.Min > 0)
                        propertySchema.MinLength = lengthValidator.Min;
                    if (lengthValidator.Max > 0 && lengthValidator.Max != int.MaxValue)
                        propertySchema.MaxLength = lengthValidator.Max;
                }

                // 4️⃣ 处理 IRegularExpressionValidator（正则匹配）
                if (validatorMetadata is IRegularExpressionValidator regexValidator)
                {
                    propertySchema.Pattern = regexValidator.Expression;
                }

                // 5️⃣ 处理 IComparisonValidator（比较运算）
                if (validatorMetadata is IComparisonValidator comparisonValidator)
                {
                    switch (comparisonValidator.Comparison)
                    {
                        case Comparison.GreaterThan:
                            propertySchema.Minimum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                            propertySchema.ExclusiveMinimum = true;
                            break;
                        case Comparison.GreaterThanOrEqual:
                            propertySchema.Minimum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                            break;
                        case Comparison.LessThan:
                            propertySchema.Maximum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                            propertySchema.ExclusiveMaximum = true;
                            break;
                        case Comparison.LessThanOrEqual:
                            propertySchema.Maximum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                            break;
                    }
                }

                // 6️⃣ 处理 IBetweenValidator（范围限定）
                if (validatorMetadata is IBetweenValidator betweenValidator)
                {
                    propertySchema.Minimum = Convert.ToDecimal(betweenValidator.From);
                    propertySchema.Maximum = Convert.ToDecimal(betweenValidator.To);

                    bool inclusive = betweenValidator.From.Equals(betweenValidator.To);
                    propertySchema.ExclusiveMinimum = !inclusive;
                    propertySchema.ExclusiveMaximum = !inclusive;
                }

            }
        }
    }
}
