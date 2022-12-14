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
    public async Task<List<PawnshopDto>> PawnshopGetList([FromQuery] int l, [FromQuery] int o, [FromQuery]string? r) {
        r ??= String.Empty;
        return await PawnS.GetPawnsList(l, o, r);
    }

    [HttpGet(ControllerBaseRoute + "/{id}")]
    public async Task<ActionResult<PawnshopDto>> PawnshopGetById(int id, string? r) {
        return Ok(await PawnS.GetPawnById(id, r ?? ""));
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

    [HttpDelete(ControllerBaseRoute + "/{id}")]
    public async Task<bool> PawnshopRemove(int id) {
        return await PawnS.Delete(id);
    }

    [HttpGet(ControllerBaseRoute + "/search")]
    public async Task<List<PawnshopDto>> PawnshopSearchByAttribute([FromQuery] string attribute,
        [FromQuery] string query, [FromQuery] int limit, [FromQuery] int offset) {
        return await PawnS.SearchBy(attribute, query, limit, offset);
    }

    [HttpGet(ControllerBaseRoute + "/sort")]
    public async Task<List<PawnshopDto>> PawnshopSortByAttribute([FromQuery] string attribute, [FromQuery] int limit,
        [FromQuery] int offset) {
        return await PawnS.SortBy(attribute, limit, offset);
    }


    #region Statistic


    [HttpGet(ControllerBaseRoute + "/statistic/getMonthAvgValues")]
    public async Task<Dictionary<string, double>> GetLastMonthAvgValue(int id) {
        return await PawnS.GetLastMonthAvgValue(id);
    }

    [HttpGet(ControllerBaseRoute + "/statistic/getLastYearMoneyIncome")]
    public async Task<Dictionary<string, double>> GetLastYearMoneyFlows(int id) {
        return await PawnS.GetLastYearMoneyFlows(id);
    }

    [HttpGet(ControllerBaseRoute + "/statistic/getPercentOfClosedMakesPerMonth")]
    public async Task<double> GetPercentOfClosedMakesPerMonth(int id) {
        return await PawnS.GetPercentOfClosedMakesPerMonth(id);
    }

    #endregion
}