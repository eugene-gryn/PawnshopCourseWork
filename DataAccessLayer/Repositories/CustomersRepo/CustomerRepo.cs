using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.CustomersRepo;

public class CustomerRepo : EfRepositoryBase<Customer>, ICustomerRepo {
    public CustomerRepo(PawnshopDbContext context) : base(context) { }

    public override async Task<Customer?> GetElementById(int id) {
        return await Context.Customers.SingleOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<Customer?> GetElementById(int id, string[] related) {
        var query = Context.Customers.Where(c => c.Id == id);

        query = ProcessingRelated(query, related);

        return await query.SingleOrDefaultAsync();
    }

    public override async Task<List<Customer>> GetAll(int limit, int offset, string[] related) {
        var query = Context.Customers.Skip(offset).Take(limit);

        query = ProcessingRelated(query, related);

        return await query.ToListAsync();
    }

    public override Customer Update(Customer entity) {
        return Context.Customers.Update(entity).Entity;
    }

    public override async Task<Customer> Add(Customer entity) {
        return (await Context.Customers.AddAsync(entity)).Entity;
    }

    public override async Task<bool> Delete(int id) {
        var el = await GetElementById(id);

        if (el == null) return false;

        return Context.Remove(el).IsKeySet;
    }

    public override async Task<List<Customer>>
        SearchByAttribute(string attribute, string query, int limit, int offset) {
        var workers = new List<Customer>();

        if (attribute == "Name")
            workers = await Context.Customers
                .Where(w => (w.FirstName + " " + w.SecondName + " " + w.ThirdName).Contains(query))
                .ToListAsync();

        return workers;
    }

    public override async Task<List<Customer>> SortByAttribute(string attribute, int limit, int offset) {
        var workers = new List<Customer>();

        if (attribute == "Birthday") await Context.Customers.OrderBy(w => w.Birthday).ToListAsync();

        return workers;
    }

    protected override IQueryable<Customer> ProcessingRelated(IQueryable<Customer> filtered, string[] relations) {
        foreach (var rel in relations)
            if (rel == "Operations")
                filtered = filtered.Include(o => o.Operations);
            else if (rel == "Makes") filtered = filtered.Include(o => o.Makes);

        return filtered;
    }
}