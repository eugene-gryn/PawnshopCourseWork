using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIWeb.Shared.SharedModels.Validation;

namespace UIWeb.Shared.SharedModels;

#nullable disable
public class Customer
{
    [Key] public int Id { get; set; }

    [Required][StringLength(50)] public string SecondName { get; set; }

    [Required][StringLength(50)] public string FirstName { get; set; }

    [StringLength(50)] public string ThirdName { get; set; } = string.Empty;

    [AgeIsGrater18]
    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; }

    [StringLength(2)]
    [Column(TypeName = "VARCHAR")]
    public string Serial { get; set; }

    [RegularExpression(@"\d{6,9}")]
    [Column(TypeName = "VARCHAR")]
    [Required]
    [StringLength(9)]
    public string Number { get; set; }
}