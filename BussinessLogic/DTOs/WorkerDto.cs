using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.DTOs;

#nullable disable
public class WorkerDto
{
    [Key] public int Id { get; set; }

    [Required][StringLength(50)] public string SecondName { get; set; }

    [Required][StringLength(50)] public string FirstName { get; set; }

    [StringLength(50)] public string ThirdName { get; set; }

    [Required] public int PositionId { get; set; }

    [Required] public int Salary { get; set; }

    [MinLength(256)] public byte[] Password { get; set; }

    [MinLength(512)] public byte[] Salt { get; set; }

    [Required] public int PawnshopId { get; set; }
    public PawnshopDto Pawnshop { get; set; }

    public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
    public ICollection<MakeDto> Mades { get; set; } = new List<MakeDto>();
}