using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public class Pawnshop {
    [Key] public int Id { get; set; }

    [Required] public int Name { get; set; }

    [Required] public City City { get; set; }

    [Required] public string Adress { get; set; }

    [Required] public DateTime TimeOpen { get; set; }

    [Required] public DateTime TimeClose { get; set; }


    public float MoneyAvailable { get; set; } = 0;

    public ICollection<Operation> Operations { get; set; } = new List<Operation>();
    public ICollection<Worker> Workers { get; set; } = new List<Worker>();
    public ICollection<Make> Makes { get; set; } = new List<Make>();
}