using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.DTOs;

#nullable disable
public class WorkerPositionDto
{
    [Key] public int Id { get; set; }

    [StringLength(50)] public string Name { get; set; }

    public ICollection<WorkerDto> Workers { get; set; } = new List<WorkerDto>();
}