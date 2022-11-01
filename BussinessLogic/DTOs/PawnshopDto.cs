using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.DTOs;

#nullable disable
public class PawnshopDto
{
    [Key] public int Id { get; set; }

    [Required, StringLength(50)] public int Name { get; set; }

    [Required] public int CityId { get; set; }

    [Required, StringLength(100)] public string Adress { get; set; }

    [Required][DataType(DataType.Time)] public DateTime TimeOpen { get; set; }

    [Required][DataType(DataType.Time)] public DateTime TimeClose { get; set; }

    public float MoneyAvailable { get; set; } = 0;

    public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
    public ICollection<WorkerDto> Workers { get; set; } = new List<WorkerDto>();
    public ICollection<MakeDto> Makes { get; set; } = new List<MakeDto>();
}