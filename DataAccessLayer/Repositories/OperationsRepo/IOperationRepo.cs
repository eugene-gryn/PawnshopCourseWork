using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.OperationsRepo;

public interface IOperationRepo : IRepository<Operation> {
    public Task<OperationType> AddOperationType (OperationType operationType);
    public Task<List<OperationType>> GetOperationTypeList ();
    public Task<OperationType?> GetOperationType(int id);
}