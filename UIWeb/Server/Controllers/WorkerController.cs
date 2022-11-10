using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using UIWeb.Shared.DTOs;

namespace UIWeb.Server.Controllers;

[ApiController]
[Route("/api/workers")]
public class WorkerController : ServerControllerBase {
    private const string ControllerBaseRoute = "/api/workers";

    public WorkerController(S workerService) {
        WorkerService = workerService;
    }

    public S WorkerService { get; }

    [HttpPost(ControllerBaseRoute + "/positions")]
    public async Task<WorkerPositionDto> AddPosition(WorkerPositionDto workerPosition) {
        return await WorkerService.AddPosition(workerPosition);
    }

    [HttpGet(ControllerBaseRoute + "/positions")]
    public async Task<List<WorkerPositionDto>> GetPositions() {
        return await WorkerService.GetPositions();
    }

    [HttpGet(ControllerBaseRoute + "/positions/{id}")]
    public async Task<WorkerPositionDto?> GetPosition(int id) {
        return await WorkerService.GetPosition(id);
    }

    [HttpPut]
    public async Task<WorkerDto> Update(WorkerDto entity) {
        return await WorkerService.Update(entity);
    }

    [HttpPost]
    public async Task<WorkerDto> Add(WorkerDto entity) {
        entity.Pawnshop = null;
        entity.Position = null;

        return await WorkerService.Add(entity);
    }

    [HttpDelete(ControllerBaseRoute + "/{id}")]
    public async Task<bool> Delete(int id) {
        return await WorkerService.Delete(id);
    }

    [HttpGet(ControllerBaseRoute + "/search")]
    public async Task<List<WorkerDto>> SearchByAttribute([FromQuery] string a, [FromQuery] string? q, [FromQuery] int l,
        [FromQuery] int o) {
        
        return await WorkerService.SearchByAttribute(a, q ?? "", l, o);
    }

    [HttpGet(ControllerBaseRoute + "/sort")]
    public async Task<List<WorkerDto>> SortByAttribute([FromQuery] string a, [FromQuery] int l, [FromQuery] int o) {
        return await WorkerService.SortByAttribute(a, l, o);
    }

    [HttpGet(ControllerBaseRoute + "/{id}")]
    public async Task<WorkerDto?> GetElementById(int id, [FromQuery] string? related) {
        string dependencies = String.Empty;
        if (related != null) dependencies = related;
        return await WorkerService.GetElementById(id, dependencies);
    }

    [HttpGet]
    public async Task<List<WorkerDto>> GetAll([FromQuery] int l, [FromQuery] int o, [FromQuery] string? r) {
        string dependencies = String.Empty;
        if (r != null) dependencies = r;
        return await WorkerService.GetAll(l, o, dependencies);
    }
}