using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.DTOs;

#nullable disable
public class OperationDto
{
    [Key] public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    [StringLength(200)] public string Description { get; set; } = string.Empty;
    public int? Sum { get; set; }

    [Required] public int OperationTypeId { get; set; }

    public int? CustomerId { get; set; }
    public CustomerDto Customer { get; set; }

    [Required] public int? WorkerId { get; set; }
    public WorkerDto Worker { get; set; }

    [Required] public int PawnshopId { get; set; }
    public PawnshopDto Pawnshop { get; set; }
}