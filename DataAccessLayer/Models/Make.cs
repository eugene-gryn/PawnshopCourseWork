using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace DataAccessLayer.Models;

public class Make {
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public int Value { get; set; }

    public float IssuancePercent { get; set; } = 80.0f;
    public SqlDateTime Income { get; set; } = DateTime.UtcNow;
    public SqlDateTime Close { get; set; } = DateTime.UtcNow.AddDays(30);
    public bool IsClosed { get; set; } = false;
    public bool IsSold { get; set; } = false;

    [Required] public int PawnshopId { get; set; }

    [Required] public int WorkerId { get; set; }

    [Required] public int CustomerId { get; set; }
}