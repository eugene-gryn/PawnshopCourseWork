using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace DataAccessLayer.Models;

public class Customer {
    [Key] public int Id { get; set; }

    [Required] public string SecondName { get; set; }

    [Required] public string FirstName { get; set; }

    public string? ThirdName { get; set; } = string.Empty;

    // Todo grater than 18!
    public SqlDateTime Birthday { get; set; }

    [Required] public string Serial { get; set; }

    [Required] public string Number { get; set; }

    public ICollection<Operation> Operations { get; set; }
    public ICollection<Make> Makes { get; set; }
}