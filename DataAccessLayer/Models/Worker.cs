using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

#nullable disable
public class Worker {
    [Key] public int Id { get; set; }

    [Required] [StringLength(50)] public string SecondName { get; set; }

    [Required] [StringLength(50)] public string FirstName { get; set; }

    [StringLength(50)] public string? ThirdName { get; set; }

    [Required] public int PositionId { get; set; }

    [Required] public int Salary { get; set; }

    [MinLength(256)] public byte[] Password { get; set; }

    [MinLength(512)] public byte[] Salt { get; set; }

    [Required] public int PawnshopId { get; set; }
    public Pawnshop Pawnshop { get; set; }

    public ICollection<Operation> Operations { get; set; } = new List<Operation>();
    public ICollection<Make> Mades { get; set; } = new List<Make>();
}