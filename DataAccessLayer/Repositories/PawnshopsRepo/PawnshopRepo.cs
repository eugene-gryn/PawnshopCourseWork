using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.PawnshopsRepo;

public class PawnshopRepo : EfRepositoryBase<Pawnshop>, IPawnshopRepo {
    public PawnshopRepo(PawnshopDbContext context) : base(context) { }

    public override Pawnshop Update(Pawnshop entity) {
        return Context.Update(entity).Entity;
    }

    public override async Task<Pawnshop?> GetElementById(int id, string[] related) {
        throw new NotImplementedException();
    }

    public override async Task<List<Pawnshop>> GetAll(int limit, int offset, string[] related) {
        var queryable = Context.Pawnshops
            .Skip(offset)
            .Take(limit);

        foreach (var rel in related)
            if (rel == "Operations")
                queryable = queryable.Include(p => p.Operations);
            else if (rel == "Workers")
                queryable = queryable.Include(p => p.Workers);
            else if (rel == "Makes") queryable = queryable.Include(p => p.Makes);
            else if (rel == "City") queryable = queryable.Include(p => p.City);

        return await queryable.ToListAsync();
    }

    public async Task<List<City>> GetCityAsync() {
        return await Context.Cities.ToListAsync();
    }

    public async Task<City?> GetCityById(int id) {
        return await Context.Cities.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task<City> AddCity(City city) {
        return (await Context.Cities.AddAsync(city)).Entity;
    }

    public override async Task<Pawnshop?> GetElementById(int id) {
        return await Context.Pawnshops.SingleOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<Pawnshop> Add(Pawnshop entity) {
        return (await Context.AddAsync(entity)).Entity;
    }

    public override async Task<bool> Delete(int id) {
        var val = await GetElementById(id);

        if (val == null) return false;

        return Context.Pawnshops.Remove(val).IsKeySet;
    }

    public override async Task<List<Pawnshop>>
        SearchByAttribute(string attribute, string query, int limit, int offset) {
        switch (attribute) {
            case "Id": {
                return await Context.Pawnshops.Where(p => p.Id.ToString().Contains(query))
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "Name": {
                return await Context.Pawnshops.Where(p => p.Name.Contains(query))
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "City": {
                var city = await Context.Cities.Where(c => c.Name.Contains(query))
                    .Include(c => c.Pawns)
                    .SingleOrDefaultAsync();
                return city?.Pawns
                           .Skip(offset)
                           .Take(limit)
                           .ToList()
                       ?? new List<Pawnshop>();
            }
            case "Address": {
                return await Context.Pawnshops.Where(p => p.Address.Contains(query))
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "MoneyAvailable": {
                var queryInt = float.Parse(query);
                return await Context.Pawnshops
                    .Where(p => Math.Abs(p.MoneyAvailable - queryInt) < 2)
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            default:
                return new List<Pawnshop>();
        }
    }

    public override async Task<List<Pawnshop>> SortByAttribute(string attribute, int limit, int offset) {
        switch (attribute) {
            case "Id": {
                return await Context.Pawnshops.OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "Name": {
                return await Context.Pawnshops.OrderBy(p => p.Name)
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "Address": {
                return await Context.Pawnshops.OrderBy(p => p.Address)
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "TimeOpen": {
                return await Context.Pawnshops.OrderBy(p => p.TimeOpen)
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "TimeClose": {
                return await Context.Pawnshops.OrderBy(p => p.TimeClose)
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            case "MoneyAvailable": {
                return await Context.Pawnshops.OrderBy(p => p.MoneyAvailable)
                    .Skip(offset)
                    .Take(limit)
                    .ToListAsync();
            }
            default:
                return new List<Pawnshop>();
        }
    }

    protected override IQueryable<Pawnshop> ProcessingRelated(IQueryable<Pawnshop> filtered, string[] relations) {
        throw new NotImplementedException();
    }
}