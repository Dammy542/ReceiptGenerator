using System.ComponentModel.DataAnnotations;

namespace ReceiptGenerator.Core.Attributes;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
public class DecimalGreaterThanZeroAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is decimal decimalValue)
        {
            return decimalValue > 0;
        }

        return false;
    }
}