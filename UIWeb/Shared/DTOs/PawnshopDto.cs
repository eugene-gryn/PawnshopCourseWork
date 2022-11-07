using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class PawnshopDto {
    public int Id { get; set; }

    [Required(ErrorMessage = "Заповнення імя обов'язкове!")]
    [StringLength(50, ErrorMessage = "Імя може мати 50 символів")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Потрібно вказати місто!")]
    public int CityId { get; set; }
    
    [Required(ErrorMessage = "Потрібно вказати місто!")]
    public CityDto City { get; set; }

    [Required(ErrorMessage = "Заповнення адреси обов'язкове!")]
    [StringLength(100, ErrorMessage = "Адреса може мати 100 символів")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Час відкриття повинен бути вказаним")]
    [DataType(DataType.Time)]
    public TimeSpan TimeOpen { get; set; } = TimeSpan.FromSeconds(1);

    [Required(ErrorMessage = "Час закриття повинен бути вказаним")]
    [DataType(DataType.Time)]
    public TimeSpan TimeClose { get; set; } = TimeSpan.FromSeconds(1);

    public float MoneyAvailable { get; set; } = 0;

    public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
    public ICollection<WorkerDto> Workers { get; set; } = new List<WorkerDto>();
    public ICollection<MakeDto> Makes { get; set; } = new List<MakeDto>();

    public override string ToString() {
        return $"{Name}";
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }
}