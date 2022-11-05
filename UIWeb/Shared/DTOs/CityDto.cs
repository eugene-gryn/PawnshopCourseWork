using System.ComponentModel.DataAnnotations;

namespace UIWeb.Shared.DTOs;
#nullable disable
public class CityDto
{
    public int Id { get; set; }

    [Required, StringLength(50)] public string Name { get; set; }

    public ICollection<PawnshopDto> Pawns { get; set; } = new List<PawnshopDto>();

    public override string ToString() {
        return $"{Name} : {Id}";
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }
}