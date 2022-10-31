using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public class Operation {
    [Key] public int Id { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string? Description { get; set; } = string.Empty;
    public int? Sum { get; set; }

    [Required] public OperationType Type { get; set; }

    public int? CustomerId { get; set; }

    [Required] public int WorkerId { get; set; }
    [Required] public int PawnshopId { get; set; }
}