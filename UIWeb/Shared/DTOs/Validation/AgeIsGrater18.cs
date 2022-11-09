using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs.Validation;

[AttributeUsage(AttributeTargets.Property)]
public class AgeIsGrater18 : ValidationAttribute {
    public string ErrorMessage { get; set; }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
        if (value is not DateTime time) return new ValidationResult(ErrorMessage);

        if (!((DateTime.UtcNow - time).Days / 365.25 > 18.0)) return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}