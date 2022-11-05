using System.Net.Http.Json;
using UIWeb.Shared.DTOs;

namespace UIWeb.Client.Services;

public class ApiClientService {
    private readonly string _pawnshopPrefix = "/api/pawnshops";

    public ApiClientService(HttpClient Http) {
        this.Http = Http;
    }

    public HttpClient Http { get; }

    public async Task<List<PawnshopDto>?> PawnshopList(int l, int o) {
        return await Http.GetFromJsonAsync<List<PawnshopDto>>($"{_pawnshopPrefix}?l={l}&o={o}");
    }

    public async Task<PawnshopDto?> PawnshopById(int id) {
        return await Http.GetFromJsonAsync<PawnshopDto?>($"{_pawnshopPrefix}/{id}");
    }

    public async Task<HttpResponseMessage> PawnshopUpdate(PawnshopDto pawnshop) {
        return await Http.PutAsJsonAsync($"{_pawnshopPrefix}", pawnshop);
    }

    public async Task<List<CityDto>?> GetCitiesList() {
        return await Http.GetFromJsonAsync<List<CityDto>>($"{_pawnshopPrefix}/cities");
    }

    public async Task<HttpResponseMessage> PawnshopAdd(PawnshopDto val) {
        return await Http.PostAsJsonAsync($"{_pawnshopPrefix}", val);
    }

    public async Task<HttpResponseMessage> CityAdd(CityDto val) {
        return await Http.PostAsJsonAsync($"{_pawnshopPrefix}/cities", val);
    }

    public async Task<CityDto?> GetCityById(int id) {
        return await Http.GetFromJsonAsync<CityDto?>($"{_pawnshopPrefix}/cities/{id}");
    }

    public async Task<bool> PawnshopDelete(int id) {
        var res = await Http.DeleteAsync($"{_pawnshopPrefix}/{id}");

        return res.IsSuccessStatusCode;
    }

    public async Task<bool> Pa(int id) {
        var res = await Http.DeleteAsync($"{_pawnshopPrefix}/{id}");

        return res.IsSuccessStatusCode;
    }

    public async Task<List<PawnshopDto>> PawnshopSearchByAttribute(string attribute, string query, int limit,
        int offset) {
        return (await Http.GetFromJsonAsync<List<PawnshopDto>>(
            $"{_pawnshopPrefix}/search?attribute={attribute}&limit={limit}&offset={offset}&query={query}"))!;
    }

    public async Task<List<PawnshopDto>> PawnshopSortByAttribute(string attribute, int limit, int offset) {
        return (await Http.GetFromJsonAsync<List<PawnshopDto>>(
            $"{_pawnshopPrefix}/sort?attribute={attribute}&limit={limit}&offset={offset}"))!;
    }
}