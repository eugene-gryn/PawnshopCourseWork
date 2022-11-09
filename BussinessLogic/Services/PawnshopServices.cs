using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.UOW;
using UIWeb.Shared.DTOs;

namespace BusinessLogic.Services;

public class PawnshopServices : BaseService {
    public PawnshopServices(IMapper mapper, IUow uow) : base(mapper, uow) { }

    public async Task<List<PawnshopDto>> GetPawnsList(int limit, int offset, string related) {
        return Mapper.Map<List<PawnshopDto>>(await Uow.Pawnshops.GetAll(limit, offset, related.Split(',')));
    }

    public async Task<PawnshopDto?> GetPawnById(int id) {
        return Mapper.Map<PawnshopDto>(await Uow.Pawnshops.GetElementById(id));
    }

    public async Task<PawnshopDto?> GetPawnById(int id, string related) {
        var relatedArr = related.Split(',');

        var list = await Uow.Pawnshops.GetElementById(id, relatedArr);

        return Mapper.Map<PawnshopDto>(list);
    }

    public PawnshopDto Update(PawnshopDto dto) {
        var res = Mapper.Map<PawnshopDto>(Uow
            .Pawnshops.Update(
                Mapper.Map<Pawnshop>(dto)));
        Uow.Save();

        return res;
    }

    public async Task<List<CityDto>> GetCites() {
        return Mapper.Map<List<CityDto>>(await Uow.Pawnshops.GetCityAsync());
    }

    public async Task<PawnshopDto> Add(PawnshopDto dto) {
        var res = Mapper.Map<PawnshopDto>(
            await Uow.Pawnshops.Add(
                Mapper.Map<Pawnshop>(dto)));

        if (res != null) await Uow.SaveAsync();

        return res;
    }

    public async Task<CityDto?> GetCity(int id) {
        return Mapper.Map<CityDto>(await Uow.Pawnshops.GetCityById(id));
    }

    public async Task<CityDto> AddCity(CityDto dto) {
        var res = Mapper.Map<CityDto>(
            await Uow.Pawnshops.AddCity(
                Mapper.Map<City>(dto)));

        if (res != null) await Uow.SaveAsync();

        return res!;
    }

    public async Task<bool> Delete(int id) {
        var res = await Uow.Pawnshops.Delete(id);

        if (res) await Uow.SaveAsync();

        return res;
    }

    public async Task<List<PawnshopDto>> SearchBy(string attribute, string query, int limit, int offset) {
        return Mapper.Map<List<PawnshopDto>>(await Uow.Pawnshops.SearchByAttribute(attribute, query, limit, offset));
    }

    public async Task<List<PawnshopDto>> SortBy(string attribute, int limit, int offset) {
        return Mapper.Map<List<PawnshopDto>>(await Uow.Pawnshops.SortByAttribute(attribute, limit, offset));
    }


    public Task<Dictionary<string, double>> GetLastMonthAvgValue(int id) {
        var dict = new Dictionary<string, double>();

        for (var month = 1; month <= 12; month++) {
            var average = Uow.Operations.ReadAsQuery()
                .Where(o => o.PawnshopId == id)
                .Where(o => month == o.Created.Month)
                .Average(o => o.Sum) ?? 0;

            var name = new DateTime(2022, month, 1).ToString("MMMM");

            dict.Add(name, average);
        }

        return Task.FromResult(dict);
    }

    public Task<Dictionary<string, double>> GetLastYearMoneyFlows(int id) {
        var dict = new Dictionary<string, double>();

        for (var month = 1; month <= 12; month++) {
            var average = Uow.Operations.ReadAsQuery()
                .Where(o => o.PawnshopId == id)
                .Where(o => o.Sum != null)
                .Where(o => DateTime.Now.Month == o.Created.Month)
                .Sum(o => Math.Abs(o.Sum.Value));


            var name = new DateTime(2022, month, 1).ToString("MMMM");

            dict.Add(name, average);
        }

        return Task.FromResult(dict);
    }

    public Task<double> GetPercentOfClosedMakesPerMonth(int id) {
        var overall = Uow.Makes
            .ReadAsQuery()
            .Count(m => m.PawnshopId == id);
        var percent = Uow.Makes
            .ReadAsQuery()
            .Count(m => m.PawnshopId == id && m.IsClosed);


        if (overall != 0) return Task.FromResult((double) percent / overall * 100);

        return Task.FromResult(0d);
    }
}