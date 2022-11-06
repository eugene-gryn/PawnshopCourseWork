using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.UOW;
using UIWeb.Shared.DTOs;

namespace BusinessLogic.Services;

public class OperationService : BaseService {
    public OperationService(IMapper mapper, IUow uow) : base(mapper, uow) { }

    public async Task<OperationTypeDto> AddOperationType(OperationTypeDto operationType) {
        return Mapper.Map<OperationTypeDto>(await Uow.Operations.AddOperationType(Mapper.Map<OperationType>(operationType)));
    }

    public async Task<List<OperationTypeDto>> GetOperationTypeList() {
        return Mapper.Map<List<OperationTypeDto>>(await Uow.Operations.GetOperationTypeList());
    }

    public async Task<OperationTypeDto?> GetOperationType(int id) {
        return Mapper.Map<OperationTypeDto>(await Uow.Operations.GetOperationType(id));
    }

    public OperationDto Update(OperationDto entity) {
        var res = Mapper.Map<OperationDto>(Uow.Operations.Update(
            Mapper.Map<Operation>(entity)));

        Uow.Save();

        return res;
    }

    public async Task<OperationDto> Add(OperationDto entity) {
        var res = Mapper.Map<OperationDto>(await Uow.Operations.Add(Mapper.Map<Operation>(entity)));

        await Uow.SaveAsync();

        return res;
    }

    public async Task<bool> Delete(int id) {
        var res = await Uow.Operations.Delete(id);

        if (res) await Uow.SaveAsync();

        return res;
    }

    public async Task<List<OperationDto>> SearchByAttribute(string attribute, string query, int limit, int offset) {
        return Mapper.Map<List<OperationDto>>(await Uow.Operations.SearchByAttribute(attribute, query, offset, limit));
    }

    public async Task<List<OperationDto>> SortByAttribute(string attribute, int limit, int offset) {
        return Mapper.Map<List<OperationDto>>(await Uow.Operations.SortByAttribute(attribute, offset, limit));
    }


    public async Task<OperationDto?> GetElementById(int id, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0) return Mapper.Map<OperationDto>(await Uow.Operations.GetElementById(id, relatedArr));

        return Mapper.Map<OperationDto>(await Uow.Operations.GetElementById(id));
    }

    public async Task<List<OperationDto>> GetAll(int limit, int offset, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0)
            return Mapper.Map<List<OperationDto>>(await Uow.Operations.GetAll(limit, offset, relatedArr));

        return Mapper.Map<List<OperationDto>>(await Uow.Operations.GetAll(limit, offset));
    }
}