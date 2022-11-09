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
        var query = Context.Pawnshops.Where(el => el.Id == id).AsNoTracking();

        query = ProcessingRelated(query, related);

        var entity = await query.SingleOrDefaultAsync();

        if (entity != null) {
            if (related.Contains("Operations")) {
                var list = await Context.Operations
                    .Include(el => el.Pawnshop)
                    .Include(el => el.Customer)
                    .Include(el => el.Worker)
                    .Include(el => el.OperationType)
                    .Where(el => el.PawnshopId == entity.Id).ToListAsync();

                foreach (var el in list) {
                    
                    entity.Operations.Add(el);
                }
            }
            if (related.Contains("Workers")) {
                var list = await Context.Workers.Where(el => el.PawnshopId == entity.Id)
                    .Include(el => el.Pawnshop)
                    .Include(el => el.Position)
                    .ToListAsync();

                foreach (var el in list)
                {
                    entity.Workers.Add(el);
                }
            }
            if (related.Contains("Makes")) {
                var list = await Context.Makes.Where(el => el.PawnshopId == entity.Id)
                    .Include(el => el.Pawnshop)
                    .Include(el => el.Customer)
                    .Include(el => el.Worker)
                    .ToListAsync();

                foreach (var el in list)
                {
                    entity.Makes.Add(el);
                }
            }
        }

        return entity;
    }

    public override async Task<List<Pawnshop>> GetAll(int limit, int offset, string[] related) {
        var queryable = Context.Pawnshops
            .Skip(offset)
            .Take(limit);

        queryable = ProcessingRelated(queryable, related);

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
        foreach (var rel in relations)
            if (rel == "City")
                filtered = filtered.Include(p => p.City);

        return filtered.AsQueryable();
    }
}