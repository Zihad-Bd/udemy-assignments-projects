
using System.ComponentModel.DataAnnotations;
namespace Assignment12.CustomValidators
{
    public class DoubleValue : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Check if value is already a double
            if (value is double) return ValidationResult.Success;
            return new ValidationResult($"{validationContext.DisplayName} must be a valid number");
        }
    }
}