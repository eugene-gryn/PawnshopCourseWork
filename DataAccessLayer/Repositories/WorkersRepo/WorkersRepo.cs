using DataAccessLayer.Context;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.WorkersRepo;

public class WorkersRepo : EfRepositoryBase<Worker>, IWorkersRepo
{
    public WorkersRepo(PawnshopDbContext context) : base(context) { }
    public override Task<Worker?> GetElementById(int id) {
        throw new NotImplementedException();
    }
}