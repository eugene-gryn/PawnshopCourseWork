using BusinessLogic.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using UIWeb.Shared.DTOs;

namespace UIWeb.Server.Controllers;

[ApiController]
[Route("/api/operations")]
public class OperationController : ServerControllerBase {
    private const string ControllerBaseRoute = "/api/operations";

    public OperationController(OperationService operationService) {
        OperationService = operationService;
    }

    public OperationService OperationService { get; }

    [HttpPost(ControllerBaseRoute + "/types")]
    public async Task<OperationTypeDto> AddOperationType(OperationTypeDto operationType) {
        return await OperationService.AddOperationType(operationType);
    }

    [HttpGet(ControllerBaseRoute + "/types")]
    public async Task<List<OperationTypeDto>> GetOperationTypeList() {
        return await OperationService.GetOperationTypeList();
    }

    [HttpGet(ControllerBaseRoute + "/types/{id}")]
    public async Task<OperationTypeDto?> GetOperationType(int id) {
        return await OperationService.GetOperationType(id);
    }

    [HttpPut]
    public OperationDto Update(OperationDto entity) {
        return OperationService.Update(entity);
    }

    [HttpPost]
    public async Task<OperationDto> Add(OperationDto entity) {
        return await OperationService.Add(entity);
    }

    [HttpDelete(ControllerBaseRoute + "/{id}")]
    public async Task<bool> Delete(int id) {
        return await OperationService.Delete(id);
    }

    [HttpGet(ControllerBaseRoute + "/search")]
    public async Task<List<OperationDto>> SearchByAttribute([FromQuery] string a, [FromQuery] string q,
        [FromQuery] int l, [FromQuery] int o) {
        return await OperationService.SearchByAttribute(a, q, l, o);
    }

    [HttpGet(ControllerBaseRoute + "/sort")]
    public async Task<List<OperationDto>> SortByAttribute([FromQuery] string a, [FromQuery] int l, [FromQuery] int o) {
        return await OperationService.SortByAttribute(a, l, o);
    }

    [HttpGet(ControllerBaseRoute + "/{id}")]
    public async Task<OperationDto?> GetElementById(int id, [FromQuery] string? related) {
        string dependencies = String.Empty;
        if (related != null) dependencies = related;
        return await OperationService.GetElementById(id, dependencies);
    }

    [HttpGet]
    public async Task<List<OperationDto>> GetAll([FromQuery] int l, [FromQuery] int o, [FromQuery] string? r) {
        string dependencies = String.Empty;
        if (r != null) dependencies = r;
        return await OperationService.GetAll(l, o, dependencies);
    }
}