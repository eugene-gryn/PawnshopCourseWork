using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class WorkerPositionDto
{
    public int Id { get; set; }

    [StringLength(50)] public string Name { get; set; }

    public ICollection<WorkerDto> Workers { get; set; } = new List<WorkerDto>();

    public override string ToString() {
        return $"{Name} : {Id}";
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }
}