using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class OperationTypeDto
{
    public int Id { get; set; }

    [Required, StringLength(50)] public string Name { get; set; }

    public override string ToString() {
        return $"{Name} - {Id}";
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }

    public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
}