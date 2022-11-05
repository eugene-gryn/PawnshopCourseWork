using AutoMapper;
using DataAccessLayer.UOW;

namespace BusinessLogic.Services;

public class BaseService {
    protected IMapper Mapper;
    protected IUow Uow;
    public BaseService(IMapper mapper, IUow uow) {
        Mapper = mapper;
        Uow = uow;
    }
}