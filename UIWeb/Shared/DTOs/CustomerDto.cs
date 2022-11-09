using System.ComponentModel.DataAnnotations;
using UIWeb.Shared.DTOs.Validation;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class CustomerDto {
    public CustomerDto() { }

    public CustomerDto(CustomerDto copy) {
        Id = copy.Id;
        SecondName = copy.SecondName;
        FirstName = copy.FirstName;
        ThirdName = copy.ThirdName;
        Birthday = copy.Birthday;
        Serial = copy.Serial;
        Number = copy.Number;
        Operations = new List<OperationDto>(copy.Operations);
        Makes = new List<MakeDto>(copy.Makes);
    }

    public int Id { get; set; }

    [Required] [StringLength(50)] public string SecondName { get; set; }

    [Required] [StringLength(50)] public string FirstName { get; set; }

    [StringLength(50)] public string ThirdName { get; set; }

    [Required]
    [AgeIsGrater18(ErrorMessage = "Клієнт має бути повнолітнім")]
    public DateTime? Birthday { get; set; }

    [StringLength(2)] public string Serial { get; set; }

    [RegularExpression(@"\d{6,9}")]
    [Required]
    [StringLength(9)]
    public string Number { get; set; }

    public ICollection<OperationDto> Operations { get; set; }
    public ICollection<MakeDto> Makes { get; set; }

    public void Restore(CustomerDto copy) {
        copy.Id = Id;
        copy.SecondName = SecondName;
        copy.FirstName = FirstName;
        copy.ThirdName = ThirdName;
        copy.Birthday = Birthday;
        copy.Serial = Serial;
        copy.Number = Number;
        copy.Operations = new List<OperationDto>(Operations);
        copy.Makes = new List<MakeDto>(Makes);
    }

    public override string ToString() {
        return $"{FirstName} {SecondName} {ThirdName} - {Number}";
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }
}