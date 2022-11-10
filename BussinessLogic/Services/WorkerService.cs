using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.UOW;
using UIWeb.Shared.DTOs;

namespace BusinessLogic.Services;

public class S : BaseService {
    public S(IMapper mapper, IUow uow) : base(mapper, uow) { }

    public async Task<WorkerPositionDto> AddPosition(WorkerPositionDto workerPosition) {
        var res = Mapper.Map<WorkerPositionDto>(
            await Uow.Workers.AddPosition(
                Mapper.Map<WorkerPosition>(workerPosition)));

        await Uow.SaveAsync();

        return res;
    }

    public async Task<List<WorkerPositionDto>> GetPositions() {
        return Mapper.Map<List<WorkerPositionDto>>(await Uow.Workers.GetPositions());
    }

    public async Task<WorkerPositionDto?> GetPosition(int id) {
        return Mapper.Map<WorkerPositionDto>(await Uow.Workers.GetPosition(id));
    }

    public async Task<WorkerDto> Update(WorkerDto entity) {
        var val = Mapper.Map<WorkerDto>(Uow.Workers.Update(
            Mapper.Map<Worker>(entity)));

        Uow.Save();

        return val;
    }

    public async Task<WorkerDto> Add(WorkerDto entity) {
        var el = Mapper.Map<WorkerDto>(await Uow.Workers.Add(Mapper.Map<Worker>(entity)));

        await Uow.SaveAsync();

        return el;
    }

    public async Task<bool> Delete(int id) {
        var res = await Uow.Workers.Delete(id);

        if (res) await Uow.SaveAsync();

        return res;
    }

    public async Task<List<WorkerDto>> SearchByAttribute(string attribute, string query, int limit, int offset) {
        return Mapper.Map<List<WorkerDto>>(await Uow.Workers.SearchByAttribute(attribute, query, offset, limit));
    }

    public async Task<List<WorkerDto>> SortByAttribute(string attribute, int limit, int offset) {
        return Mapper.Map<List<WorkerDto>>(await Uow.Workers.SortByAttribute(attribute, offset, limit));
    }

    public async Task<WorkerDto?> GetElementById(int id, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0) {
            return Mapper.Map<WorkerDto>(await Uow.Workers.GetElementById(id, relatedArr));
        }

        return Mapper.Map<WorkerDto>(await Uow.Workers.GetElementById(id));
    }

    public async Task<List<WorkerDto>> GetAll(int limit, int offset, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0) {
            return Mapper.Map<List<WorkerDto>>(await Uow.Workers.GetAll(limit, offset, relatedArr));
        }

        return Mapper.Map<List<WorkerDto>>(await Uow.Workers.GetAll(limit, offset));
    }
}