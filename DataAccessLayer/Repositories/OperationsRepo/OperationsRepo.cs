using DataAccessLayer.Context;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WorkersRepo;

namespace DataAccessLayer.Repositories.OperationsRepo; 

public class OperationsRepo : EfRepositoryBase<Operation>, IOperationRepo {
    public OperationsRepo(PawnshopDbContext context) : base(context) { }
    public override Task<Operation> GetElementById(int id) {
        throw new NotImplementedException();
    }
}