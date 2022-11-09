using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.MakesRepo;

public class MakesRepo : EfRepositoryBase<Make>, IMakesRepo {
    public MakesRepo(PawnshopDbContext context) : base(context) { }

    public override async Task<Make?> GetElementById(int id) {
        return await Context.Makes.SingleOrDefaultAsync(m => m.Id == id);
    }

    public override async Task<Make?> GetElementById(int id, string[] related) {
        var query = Context.Makes.Where(m => m.Id == id);

        query = ProcessingRelated(query, related);

        return await query.SingleOrDefaultAsync();
    }

    public override async Task<List<Make>> GetAll(int limit, int offset, string[] related) {
        var query = Context.Makes.Skip(offset).Take(limit);

        query = ProcessingRelated(query, related);

        return await query.ToListAsync();
    }

    public override Make Update(Make entity) {
        return Context.Makes.Update(entity).Entity;
    }

    public override async Task<Make> Add(Make entity) {
        return (await Context.Makes.AddAsync(entity)).Entity;
    }

    public override async Task<bool> Delete(int id) {
        var el = await GetElementById(id);

        if (el == null) return false;

        return Context.Remove(el).IsKeySet;
    }

    public override async Task<List<Make>> SearchByAttribute(string attribute, string query, int limit, int offset) {
        var makes = new List<Make>();

        if (attribute == "Name") {
            makes = await Context.Makes.Where(m => m.Name.Contains(query))
                
                .ToListAsync();
        }
        else {
            var queryable = Context.Makes
                .Include(m => m.Pawnshop)
                .Include(m => m.Worker)
                .Include(m => m.Customer)
                .AsQueryable();

            if (attribute == "Pawnshop") {
                queryable = queryable
                    .Where(m => m.Pawnshop.Name.Contains(query));
            }
            else if (attribute == "Worker") {
                queryable = queryable
                    .Where(m =>
                    m.Worker.FirstName.Contains(query) ||
                    m.Worker.SecondName.Contains(query) ||
                    m.Worker.SecondName.Contains(query));

            }
            else if (attribute == "Customer") {
                queryable = queryable
                    .Where(m =>
                        m.Worker.FirstName.Contains(query) ||
                        m.Worker.SecondName.Contains(query) ||
                        m.Worker.SecondName.Contains(query));

            }

            makes = await queryable.ToListAsync();
        }

        return makes;
    }

    public override async Task<List<Make>> SortByAttribute(string attribute, int limit, int offset) {
        var makes = new List<Make>();

        if (attribute == "IsClosed")
            makes = await Context.Makes.Where(m => m.IsClosed).ToListAsync();
        else if (attribute == "IsSold")
            makes = await Context.Makes.Where(m => m.IsSold).ToListAsync();
        else if (attribute == "Name") makes = await Context.Makes.OrderBy(m => m.Name).ToListAsync();

        return makes;
    }

    protected override IQueryable<Make> ProcessingRelated(IQueryable<Make> filtered, string[] relations) {
        foreach (var rel in relations) {
            if (rel == "Pawnshop") {
                filtered = filtered.Include(m => m.Pawnshop);
            }
            else if (rel == "Worker") {
                filtered = filtered.Include(m => m.Worker);
            }
            else if (rel == "Customer") {
                filtered = filtered.Include(m => m.Customer);
            }
        }
        return filtered;
    }
}