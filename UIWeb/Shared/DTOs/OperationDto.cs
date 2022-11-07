using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;

#nullable disable
public class OperationDto
{
    public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    [StringLength(200)] public string Description { get; set; } = string.Empty;
    public int? Sum { get; set; }

    [Required] public int OperationTypeId { get; set; }
    [Required] public OperationTypeDto OperationType { get; set; }

    public int? CustomerId { get; set; }
    public CustomerDto? Customer { get; set; }

    [Required] public int? WorkerId { get; set; }
    [Required] public CustomerDto? Worker { get; set; }

    [Required] public int PawnshopId { get; set; }
    [Required] public PawnshopDto Pawnshop { get; set; }
}