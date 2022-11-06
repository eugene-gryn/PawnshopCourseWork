using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using UIWeb.Shared.DTOs;

namespace UIWeb.Server.Controllers;

[ApiController]
[Route("/api/customers")]
public class CustomerController : ServerControllerBase {
    private const string ControllerBaseRoute = "/api/customers";

    public CustomerController(CustomerService customerService) {
        CustomerService = customerService;
    }

    public CustomerService CustomerService { get; }

    [HttpPut]
    public CustomerDto Update(CustomerDto entity) {
        return CustomerService.Update(entity);
    }

    [HttpPost]
    public async Task<CustomerDto> Add(CustomerDto entity) {
        return await CustomerService.Add(entity);
    }
    [HttpDelete(ControllerBaseRoute + "/{id}")]
    public async Task<bool> Delete(int id) {
        return await CustomerService.Delete(id);
    }

    [HttpGet(ControllerBaseRoute + "/search")]
    public async Task<List<CustomerDto>> SearchByAttribute([FromQuery]string a, [FromQuery] string q, [FromQuery] int l, [FromQuery] int o) {
        return await CustomerService.SearchByAttribute(a, q, l, o);
    }
    [HttpGet(ControllerBaseRoute + "/sort")]
    public async Task<List<CustomerDto>> SortByAttribute([FromQuery] string a, [FromQuery] int l, [FromQuery] int o) {
        return await CustomerService.SortByAttribute(a, l, o);
    }

    [HttpGet(ControllerBaseRoute + "/{id}")]
    public async Task<CustomerDto?> GetElementById(int id, [FromQuery] string? related) {
        var dependencies = string.Empty;
        if (related != null) dependencies = related;
        return await CustomerService.GetElementById(id, dependencies);
    }

    [HttpGet]
    public async Task<List<CustomerDto>> GetAll([FromQuery]int l, [FromQuery] int o, [FromQuery] string? r) {
        string dependencies = String.Empty;
        if (r != null) dependencies = r;
        return await CustomerService.GetAll(l, o, dependencies);
    }
}