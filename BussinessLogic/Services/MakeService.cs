using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.UOW;
using UIWeb.Shared.DTOs;

namespace BusinessLogic.Services;

public class MakeService : BaseService {
    public MakeService(IMapper mapper, IUow uow) : base(mapper, uow) { }

    public MakeDto Update(MakeDto entity) {
        var res = Mapper.Map<MakeDto>(Uow.Makes.Update(
            Mapper.Map<Make>(entity)));

        Uow.Save();

        return res;
    }

    public async Task<MakeDto> Add(MakeDto entity) {
        var res = Mapper.Map<MakeDto>(await Uow.Makes.Add(Mapper.Map<Make>(entity)));

        await Uow.SaveAsync();

        return res;
    }

    public async Task<bool> Delete(int id) {
        var res = await Uow.Makes.Delete(id);

        await Uow.SaveAsync();

        return res;
    }

    public async Task<List<MakeDto>> SearchByAttribute(string attribute, string query, int limit, int offset) {
        return Mapper.Map<List<MakeDto>>(await Uow.Makes.SearchByAttribute(attribute, query, offset, limit));
    }

    public async Task<List<MakeDto>> SortByAttribute(string attribute, int limit, int offset) {
        return Mapper.Map<List<MakeDto>>(await Uow.Makes.SortByAttribute(attribute, offset, limit));
    }

    public async Task<MakeDto?> GetElementById(int id, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0) return Mapper.Map<MakeDto>(await Uow.Makes.GetElementById(id, relatedArr));

        return Mapper.Map<MakeDto>(await Uow.Makes.GetElementById(id));
    }

    public async Task<List<MakeDto>> GetAll(int limit, int offset, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0) return Mapper.Map<List<MakeDto>>(await Uow.Makes.GetAll(limit, offset, relatedArr));

        return Mapper.Map<List<MakeDto>>(await Uow.Makes.GetAll(limit, offset));
    }
}