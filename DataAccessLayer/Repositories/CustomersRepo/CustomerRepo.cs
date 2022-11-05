using DataAccessLayer.Context;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.WorkersRepo;

namespace DataAccessLayer.Repositories.CustomersRepo; 

public class CustomerRepo : EfRepositoryBase<Customer>, ICustomerRepo {
    public CustomerRepo(PawnshopDbContext context) : base(context) { }
    public override Task<Customer?> GetElementById(int id) {
        throw new NotImplementedException();
    }
}