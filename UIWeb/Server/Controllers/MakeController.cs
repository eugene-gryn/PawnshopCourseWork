using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using UIWeb.Shared.DTOs;

namespace UIWeb.Server.Controllers;

[ApiController]
[Route("/api/makes")]
public class MakeController : ServerControllerBase {
    private const string ControllerBaseRoute = "/api/makes";

    public MakeController(MakeService makeService) {
        MakeService = makeService;
    }

    public MakeService MakeService { get; }

    [HttpPut]
    public MakeDto Update(MakeDto entity) {
        return MakeService.Update(entity);
    }

    [HttpPost]
    public async Task<MakeDto> Add(MakeDto entity) {
        return await MakeService.Add(entity);
    }

    [HttpDelete(ControllerBaseRoute + "/{id}")]
    public async Task<bool> Delete(int id) {
        return await MakeService.Delete(id);
    }

    [HttpGet(ControllerBaseRoute + "/search")]
    public async Task<List<MakeDto>> SearchByAttribute([FromQuery] string a, [FromQuery] string q, [FromQuery] int l,
        [FromQuery] int o) {
        return await MakeService.SearchByAttribute(a, q, l, o);
    }

    [HttpGet(ControllerBaseRoute + "/sort")]
    public async Task<List<MakeDto>> SortByAttribute([FromQuery] string a, [FromQuery] int l, [FromQuery] int o) {
        return await MakeService.SortByAttribute(a, l, o);
    }

    [HttpGet(ControllerBaseRoute + "/{id}")]
    public async Task<MakeDto?> GetElementById(int id, [FromQuery] string? related) {
        var dependencies = string.Empty;
        if (related != null) dependencies = related;
        return await MakeService.GetElementById(id, dependencies);
    }

    [HttpGet]
    public async Task<List<MakeDto>> GetAll([FromQuery] int l, [FromQuery] int o, [FromQuery] string? r) {
        string dependencies = String.Empty;
        if (r != null) dependencies = r;
        return await MakeService.GetAll(l, o, dependencies);
    }
}