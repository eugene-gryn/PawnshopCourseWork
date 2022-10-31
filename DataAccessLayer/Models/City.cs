using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;
#nullable disable
public class City {
    [Key] public int Id { get; set; }

    [Required, StringLength(50)] public string Name { get; set; }

    public ICollection<Pawnshop> Pawns { get; set; } = new List<Pawnshop>();
}