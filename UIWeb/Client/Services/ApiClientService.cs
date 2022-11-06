using System.Net.Http.Json;
using UIWeb.Shared.DTOs;

namespace UIWeb.Client.Services;

public class ApiClientService {
    private const string CustomerPrefix = "/api/customers";
    private const string MakePrefix = "/api/makes";
    private const string OperationPrefix = "/api/operations";
    private const string PawnshopPrefix = "/api/pawnshops";
    public const string WorkerPrefix = "/api/workers";


    public ApiClientService(HttpClient Http) {
        this.Http = Http;
    }

    public HttpClient Http { get; }

    public async Task<List<PawnshopDto>?> PawnshopList(int l, int o) {
        return await Http.GetFromJsonAsync<List<PawnshopDto>>($"{PawnshopPrefix}?l={l}&o={o}");
    }

    public async Task<PawnshopDto?> PawnshopById(int id) {
        return await Http.GetFromJsonAsync<PawnshopDto?>($"{PawnshopPrefix}/{id}");
    }

    public async Task<HttpResponseMessage> PawnshopUpdate(PawnshopDto pawnshop) {
        return await Http.PutAsJsonAsync($"{PawnshopPrefix}", pawnshop);
    }

    public async Task<List<CityDto>?> GetCitiesList() {
        return await Http.GetFromJsonAsync<List<CityDto>>($"{PawnshopPrefix}/cities");
    }

    public async Task<HttpResponseMessage> PawnshopAdd(PawnshopDto val) {
        return await Http.PostAsJsonAsync($"{PawnshopPrefix}", val);
    }

    public async Task<HttpResponseMessage> CityAdd(CityDto val) {
        return await Http.PostAsJsonAsync($"{PawnshopPrefix}/cities", val);
    }

    public async Task<CityDto?> GetCityById(int id) {
        return await Http.GetFromJsonAsync<CityDto?>($"{PawnshopPrefix}/cities/{id}");
    }

    public async Task<bool> PawnshopDelete(int id) {
        var res = await Http.DeleteAsync($"{PawnshopPrefix}/{id}");

        return res.IsSuccessStatusCode;
    }

    public async Task<bool> Pa(int id) {
        var res = await Http.DeleteAsync($"{PawnshopPrefix}/{id}");

        return res.IsSuccessStatusCode;
    }

    public async Task<List<PawnshopDto>> PawnshopSearchByAttribute(string attribute, string query, int limit,
        int offset) {
        return (await Http.GetFromJsonAsync<List<PawnshopDto>>(
            $"{PawnshopPrefix}/search?attribute={attribute}&limit={limit}&offset={offset}&query={query}"))!;
    }

    public async Task<List<PawnshopDto>> PawnshopSortByAttribute(string attribute, int limit, int offset) {
        return (await Http.GetFromJsonAsync<List<PawnshopDto>>(
            $"{PawnshopPrefix}/sort?attribute={attribute}&limit={limit}&offset={offset}"))!;
    }

    public async Task<OperationTypeDto?> AddOperationType(OperationTypeDto operationType) {
        var res = await Http.PostAsJsonAsync($"{OperationPrefix}/types", operationType);

        return await res.Content.ReadFromJsonAsync<OperationTypeDto>();
    }

    public async Task<List<OperationTypeDto>?> GetOperationTypeList() {
        return await Http.GetFromJsonAsync<List<OperationTypeDto>>($"{OperationPrefix}/types");
    }

    public async Task<OperationTypeDto?> GetOperationType(int id) {
        return await Http.GetFromJsonAsync<OperationTypeDto>($"{OperationPrefix}/types/{id}");
    }

    public async Task<WorkerPositionDto?> AddWorkerPosition(WorkerPositionDto operationType) {
        var res = await Http.PostAsJsonAsync($"{WorkerPrefix}/positions", operationType);

        return await res.Content.ReadFromJsonAsync<WorkerPositionDto>();
    }

    public async Task<List<WorkerPositionDto>?> GetWorkerPositions() {
        return await Http.GetFromJsonAsync<List<WorkerPositionDto>>($"{WorkerPrefix}/positions");
    }

    public async Task<WorkerPositionDto?> GetWorkerPosition(int id) {
        return await Http.GetFromJsonAsync<WorkerPositionDto>($"{WorkerPrefix}/positions/{id}");
    }


    #region OperationMethods

    public async Task<OperationDto?> OperationUpdate(OperationDto entity)
    {
        var res = await Http.PutAsJsonAsync($"{OperationPrefix}", entity);

        return await res.Content.ReadFromJsonAsync<OperationDto>();
    }

    public async Task<OperationDto?> OperationAdd(OperationDto entity)
    {
        var res = await Http.PostAsJsonAsync($"{OperationPrefix}", entity);

        return await res.Content.ReadFromJsonAsync<OperationDto>();
    }

    public async Task<bool> OperationDelete(int id)
    {
        var res = await Http.DeleteAsync($"{OperationPrefix}/{id}");

        return await res.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<OperationDto>?> OperationSearchByAttribute(string attribute, string query,
        int limit, int offset)
    {
        return await Http.GetFromJsonAsync<List<OperationDto>>(
            $"{OperationPrefix}/search?a={attribute}&q={query}&l={limit}&o={offset}");
    }

    public async Task<List<OperationDto>?> OperationSortByAttribute(string attribute, int limit, int offset) {
        return await Http.GetFromJsonAsync<List<OperationDto>>(
            $"{OperationPrefix}/sort?a={attribute}&l={limit}&o={offset}");
    }

    public async Task<OperationDto?> OperationGetElementById(int id, string related)
    {
        return await Http.GetFromJsonAsync<OperationDto?>($"{OperationPrefix}/{id}?related={related}");
    }

    public async Task<List<OperationDto>?> OperationGetAll(int limit, int offset, string related)
    {
        return await Http.GetFromJsonAsync<List<OperationDto>>($"{OperationPrefix}?l={limit}&o={offset}&r={related}");
    }

    #endregion


    #region Customer

    public async Task<CustomerDto?> CustomerUpdate(CustomerDto entity)
    {
        var res = await Http.PutAsJsonAsync($"{CustomerPrefix}", entity);

        return await res.Content.ReadFromJsonAsync<CustomerDto>();
    }

    public async Task<CustomerDto?> CustomerAdd(CustomerDto entity)
    {
        var res = await Http.PostAsJsonAsync($"{CustomerPrefix}", entity);

        return await res.Content.ReadFromJsonAsync<CustomerDto>();
    }

    public async Task<bool> CustomerDelete(int id)
    {
        var res = await Http.DeleteAsync($"{CustomerPrefix}/{id}");

        return await res.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<CustomerDto>?> CustomerSearchByAttribute(string attribute, string query,
        int limit, int offset)
    {
        return await Http.GetFromJsonAsync<List<CustomerDto>>(
            $"{CustomerPrefix}/search?a={attribute}&q={query}&l={limit}&o={offset}");
    }

    public async Task<List<CustomerDto>?> CustomerSortByAttribute(string attribute, int limit, int offset)
    {
        return await Http.GetFromJsonAsync<List<CustomerDto>>(
            $"{CustomerPrefix}/sort?a={attribute}&l={limit}&o={offset}");
    }

    public async Task<CustomerDto?> CustomerGetElementById(int id, string related)
    {
        return await Http.GetFromJsonAsync<CustomerDto?>($"{CustomerPrefix}/{id}?related={related}");
    }

    public async Task<List<CustomerDto>?> CustomerGetAll(int limit, int offset, string related)
    {
        return await Http.GetFromJsonAsync<List<CustomerDto>>($"{CustomerPrefix}?l={limit}&o={offset}&r={related}");
    }

    #endregion


    #region Worker

    public async Task<WorkerDto?> WorkerUpdate(WorkerDto entity)
    {
        var res = await Http.PutAsJsonAsync($"{WorkerPrefix}", entity);

        return await res.Content.ReadFromJsonAsync<WorkerDto>();
    }

    public async Task<WorkerDto?> WorkerAdd(WorkerDto entity)
    {
        var res = await Http.PostAsJsonAsync($"{WorkerPrefix}", entity);

        return await res.Content.ReadFromJsonAsync<WorkerDto>();
    }

    public async Task<bool> WorkerDelete(int id)
    {
        var res = await Http.DeleteAsync($"{WorkerPrefix}/{id}");

        return await res.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<WorkerDto>?> WorkerSearchByAttribute(string attribute, string query,
        int limit, int offset)
    {
        return await Http.GetFromJsonAsync<List<WorkerDto>>(
            $"{WorkerPrefix}/search?a={attribute}&q={query}&l={limit}&o={offset}");
    }

    public async Task<List<WorkerDto>?> WorkerSortByAttribute(string attribute, int limit, int offset)
    {
        return await Http.GetFromJsonAsync<List<WorkerDto>>(
            $"{WorkerPrefix}/sort?a={attribute}&l={limit}&o={offset}");
    }

    public async Task<WorkerDto?> WorkerGetElementById(int id, string related)
    {
        return await Http.GetFromJsonAsync<WorkerDto?>($"{WorkerPrefix}/{id}?related={related}");
    }

    public async Task<List<WorkerDto>?> WorkerGetAll(int limit, int offset, string related)
    {
        return await Http.GetFromJsonAsync<List<WorkerDto>>($"{WorkerPrefix}?l={limit}&o={offset}&r={related}");
    }

    #endregion


    #region Make

    public async Task<MakeDto?> MakeUpdate(MakeDto entity)
    {
        var res = await Http.PutAsJsonAsync($"{MakePrefix}", entity);

        return await res.Content.ReadFromJsonAsync<MakeDto>();
    }

    public async Task<MakeDto?> MakeAdd(MakeDto entity)
    {
        var res = await Http.PostAsJsonAsync($"{MakePrefix}", entity);

        return await res.Content.ReadFromJsonAsync<MakeDto>();
    }

    public async Task<bool> MakeDelete(int id)
    {
        var res = await Http.DeleteAsync($"{MakePrefix}/{id}");

        return await res.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<List<MakeDto>?> MakeSearchByAttribute(string attribute, string query,
        int limit, int offset)
    {
        return await Http.GetFromJsonAsync<List<MakeDto>>(
            $"{MakePrefix}/search?a={attribute}&q={query}&l={limit}&o={offset}");
    }

    public async Task<List<MakeDto>?> MakeSortByAttribute(string attribute, int limit, int offset)
    {
        return await Http.GetFromJsonAsync<List<MakeDto>>(
            $"{MakePrefix}/sort?a={attribute}&l={limit}&o={offset}");
    }

    public async Task<MakeDto?> MakeGetElementById(int id, string related)
    {
        return await Http.GetFromJsonAsync<MakeDto?>($"{MakePrefix}/{id}?related={related}");
    }

    public async Task<List<MakeDto>?> MakeGetAll(int limit, int offset, string related)
    {
        return await Http.GetFromJsonAsync<List<MakeDto>>($"{MakePrefix}?l={limit}&o={offset}&r={related}");
    }

    #endregion
}