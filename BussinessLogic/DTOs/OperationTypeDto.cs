using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.DTOs;

#nullable disable
public class OperationTypeDto
{
    [Key] public int Id { get; set; }

    [Required, StringLength(50)] public string Name { get; set; }

    public ICollection<OperationDto> Operations { get; set; } = new List<OperationDto>();
}