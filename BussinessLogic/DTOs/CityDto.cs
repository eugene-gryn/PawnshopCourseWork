using System.ComponentModel.DataAnnotations;

namespace BussinessLogic.DTOs;
#nullable disable
public class CityDto
{
    [Key] public int Id { get; set; }

    [Required, StringLength(50)] public string Name { get; set; }

    public ICollection<PawnshopDto> Pawns { get; set; } = new List<PawnshopDto>();
}