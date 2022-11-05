using DataAccessLayer.Repositories.CustomersRepo;
using DataAccessLayer.Repositories.MakesRepo;
using DataAccessLayer.Repositories.OperationsRepo;
using DataAccessLayer.Repositories.PawnshopsRepo;
using DataAccessLayer.Repositories.WorkersRepo;

namespace DataAccessLayer.UOW;

public interface IUow {
    ICustomerRepo Customers { get; }
    IMakesRepo Makes { get; }
    IOperationRepo Operations { get; }
    IPawnshopRepo Pawnshops { get; }
    IWorkersRepo Workers { get; }

    public void Save();
    public Task SaveAsync();
}