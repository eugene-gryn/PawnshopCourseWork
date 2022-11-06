using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.UOW;
using UIWeb.Shared.DTOs;

namespace BusinessLogic.Services;

public class CustomerService : BaseService {
    public CustomerService(IMapper mapper, IUow uow) : base(mapper, uow) { }

    public CustomerDto Update(CustomerDto entity) {
        var res = Mapper.Map<CustomerDto>(Uow.Customers.Update(
            Mapper.Map<Customer>(entity)));

        Uow.Save();

        return res;
    }

    public async Task<CustomerDto> Add(CustomerDto entity) {
        var res = Mapper.Map<CustomerDto>(await Uow.Customers.Add(Mapper.Map<Customer>(entity)));

        await Uow.SaveAsync();

        return res;
    }

    public async Task<bool> Delete(int id) {
        var res = await Uow.Customers.Delete(id);

        if (res) await Uow.SaveAsync();

        return res;
    }

    public async Task<List<CustomerDto>> SearchByAttribute(string attribute, string query, int limit, int offset) {
        return Mapper.Map<List<CustomerDto>>(await Uow.Customers.SearchByAttribute(attribute, query, offset, limit));
    }

    public async Task<List<CustomerDto>> SortByAttribute(string attribute, int limit, int offset) {
        return Mapper.Map<List<CustomerDto>>(await Uow.Customers.SortByAttribute(attribute, offset, limit));
    }

    public async Task<CustomerDto?> GetElementById(int id, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0) {
            return Mapper.Map<CustomerDto>(await Uow.Customers.GetElementById(id, relatedArr));
        }

        return Mapper.Map<CustomerDto>(await Uow.Customers.GetElementById(id));
    }

    public async Task<List<CustomerDto>> GetAll(int limit, int offset, string related) {
        var relatedArr = related.Split(',');

        if (relatedArr.Length > 0) {
            return Mapper.Map<List<CustomerDto>>(await Uow.Customers.GetAll(limit, offset, relatedArr));
        }
        
        return Mapper.Map<List<CustomerDto>>(await Uow.Customers.GetAll(limit, offset));
    }
}