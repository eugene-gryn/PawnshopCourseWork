using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models.Validation;

[AttributeUsage(AttributeTargets.Property)]
public class AgeIsGrater18 : ValidationAttribute {
    public override bool IsValid(object value)
    {
        if (!(value is DateTime)) {
            return false;
        }

        DateTime Date = (DateTime) value;

        return (DateTime.UtcNow - Date).Days / 365.25 > 18.0;
    }
}