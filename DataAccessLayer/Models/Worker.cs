using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public class Worker {
    [Key] public int Id { get; set; }

    [Required] public string SecondName { get; set; }

    [Required] public string FirstName { get; set; }

    public string? ThirdName { get; set; }

    [Required] public WorkerPosition Position { get; set; }

    [Required] public int Salary { get; set; }


    public byte[] Password { get; set; }
    public byte[] Salt { get; set; }

    [Required] public int PawnshopId { get; set; }

    public ICollection<Operation> Operations { get; set; } = new List<Operation>();
    public ICollection<Make> MadeMakes { get; set; } = new List<Make>();
}