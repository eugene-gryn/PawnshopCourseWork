using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace BussinessLogic.DTOs;
#nullable disable
public class MakeDto
{
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public int Value { get; set; }

    public float IssuancePercent { get; set; } = 80.0f;
    public DateTime Income { get; set; } = DateTime.UtcNow;
    public DateTime Close { get; set; } = DateTime.UtcNow.AddDays(30);
    public bool IsClosed { get; set; } = false;
    public bool IsSold { get; set; } = false;

    [Required] public int PawnshopId { get; set; }
    public PawnshopDto Pawnshop { get; set; }

    public int? WorkerId { get; set; }
    public WorkerDto? Worker { get; set; }

    public int? CustomerId { get; set; }
    public CustomerDto? Customer { get; set; }
}