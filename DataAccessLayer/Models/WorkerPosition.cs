using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

#nullable disable
public class WorkerPosition {
    [Key] public int Id { get; set; }

    [StringLength(50)] public string Name { get; set; }

    public ICollection<Worker> Workers { get; set; } = new List<Worker>();
}