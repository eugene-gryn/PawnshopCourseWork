using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using UIWeb.Shared.DTOs;

namespace UIWeb.Server.Controllers;

[ApiController]
[Route("/api/pawnshops")]
public class PawnshopsController : ServerControllerBase {
    private const string ControllerBaseRoute = "/api/pawnshops";

    public PawnshopsController(PawnshopServices pawnS) {
        PawnS = pawnS;
    }

    public PawnshopServices PawnS { get; }

    [HttpGet]
    public async Task<List<PawnshopDto>> PawnshopGetList([FromQuery] int l, [FromQuery] int o) {
        return await PawnS.GetPawnsList(l, o);
    }

    [HttpGet(ControllerBaseRoute + "/{id}")]
    public async Task<ActionResult<PawnshopDto>> PawnshopGetById(int id) {
        return Ok(await PawnS.GetPawnById(id));
    }

    [HttpPut]
    public PawnshopDto PawnshopUpdate(PawnshopDto pawnshop) {
        return PawnS.Update(pawnshop);
    }

    [HttpGet(ControllerBaseRoute + "/cities")]
    public async Task<List<CityDto>> GetCities() {
        return await PawnS.GetCites();
    }

    [HttpPost]
    public async Task<PawnshopDto> PawnshopAdd(PawnshopDto val) {
        return await PawnS.Add(val);
    }

    [HttpPost(ControllerBaseRoute + "/cities")]
    public async Task<CityDto> CityAdd(CityDto val) {
        return await PawnS.AddCity(val);
    }

    [HttpGet(ControllerBaseRoute + "/cities/{id}")]
    public async Task<CityDto?> GetCityById(int id) {
        return await PawnS.GetCity(id);
    }
}