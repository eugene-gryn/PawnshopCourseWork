using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UIWeb.Shared.DTOs.Validation;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class CustomerDto
{
    public int Id { get; set; }

    [Required][StringLength(50)] public string SecondName { get; set; }

    [Required][StringLength(50)] public string FirstName { get; set; }

    [StringLength(50)] public string ThirdName { get; set; } = string.Empty;

    [AgeIsGrater18]
    public DateTime Birthday { get; set; }

    [StringLength(2)]
    public string Serial { get; set; }

    [RegularExpression(@"\d{6,9}")]
    [Required]
    [StringLength(9)]
    public string Number { get; set; }

    public ICollection<OperationDto> Operations { get; set; }
    public ICollection<MakeDto> Makes { get; set; }
}