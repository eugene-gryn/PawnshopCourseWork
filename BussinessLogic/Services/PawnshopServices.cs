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

}