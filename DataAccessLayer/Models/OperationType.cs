using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

#nullable disable
public class OperationType {
    [Key] public int Id { get; set; }

    [Required, StringLength(50)] public string Name { get; set; }

    public ICollection<Operation> Operations { get; set; } = new List<Operation>();
}