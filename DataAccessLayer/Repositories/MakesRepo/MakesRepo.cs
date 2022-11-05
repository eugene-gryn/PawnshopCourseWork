using DataAccessLayer.Context;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WorkersRepo;

namespace DataAccessLayer.Repositories.MakesRepo; 

public class MakesRepo : EfRepositoryBase<Make>, IMakesRepo {
    public MakesRepo(PawnshopDbContext context) : base(context) { }
    public override Task<Make?> GetElementById(int id) {
        throw new NotImplementedException();
    }
}