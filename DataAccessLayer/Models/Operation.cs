using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public class Operation {
    [Key] public int Id { get; set; }

    [DataType(DataType.DateTime)] public DateTime Created { get; set; } = DateTime.UtcNow;
    [StringLength(200)] public string? Description { get; set; } = string.Empty;
    public int? Sum { get; set; }

    [Required] public int OperationTypeId { get; set; }
    [Required] public OperationType OperationType { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [Required] public int? WorkerId { get; set; }
    [Required] public Worker? Worker { get; set; }


    [Required] public int PawnshopId { get; set; }
    [Required] public Pawnshop Pawnshop { get; set; }
}