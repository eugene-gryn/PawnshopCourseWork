using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class WorkerDto {
    public WorkerDto() { }

    public WorkerDto(WorkerDto dto) {
        Id = dto.Id;
        SecondName = dto.SecondName;
        FirstName = dto.FirstName;
        ThirdName = dto.ThirdName;
        PositionId = dto.PositionId;
        Position = dto.Position;
        Salary = dto.Salary;
        PawnshopId = dto.PawnshopId;
        Pawnshop = dto.Pawnshop;
        Operations = new List<OperationDto>(dto.Operations);
        Mades = new List<MakeDto>(dto.Mades);
    }

    public void Restore(WorkerDto dto) {
        Id = dto.Id;
        SecondName = dto.SecondName;
        FirstName = dto.FirstName;
        ThirdName = dto.ThirdName;
        PositionId = dto.PositionId;
        Position = dto.Position;
        Salary = dto.Salary;
        PawnshopId = dto.PawnshopId;
        Pawnshop = dto.Pawnshop;
        Operations = new List<OperationDto>(dto.Operations);
        Mades = new List<MakeDto>(dto.Mades);
    }

    public int Id { get; set; }

    [Required] [StringLength(50)] public string SecondName { get; set; }

    [Required] [StringLength(50)] public string FirstName { get; set; }

    [StringLength(50)] public string ThirdName { get; set; }

    [Required] public int PositionId { get; set; }
    [Required] public WorkerPositionDto Position { get; set; }
    [Required] public int Salary { get; set; }

    [Required] public int PawnshopId { get; set; }
    [Required] public PawnshopDto Pawnshop { get; set; }

    public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
    public ICollection<MakeDto> Mades { get; set; } = new List<MakeDto>();
}