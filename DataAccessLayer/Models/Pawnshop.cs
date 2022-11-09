using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

#nullable disable
public class Pawnshop {
    [Key] public int Id { get; set; }

    [Required, StringLength(50)] public string Name { get; set; }

    [Required] public int CityId { get; set; }
    public City City { get; set; }

    [Required, StringLength(100)] public string Address { get; set; }

    [Required] [DataType(DataType.Time)] public TimeSpan TimeOpen { get; set; }

    [Required] [DataType(DataType.Time)] public TimeSpan TimeClose { get; set; }

    public float MoneyAvailable { get; set; } = 0;

    public ICollection<Operation> Operations { get; set; } = new List<Operation>();
    public ICollection<Worker> Workers { get; set; } = new List<Worker>();
    public ICollection<Make> Makes { get; set; } = new List<Make>();
}