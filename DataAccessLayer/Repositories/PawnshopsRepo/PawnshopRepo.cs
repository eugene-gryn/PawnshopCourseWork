using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.PawnshopsRepo;

public class PawnshopRepo : EfRepositoryBase<Pawnshop>, IPawnshopRepo {
    public PawnshopRepo(PawnshopDbContext context) : base(context) { }

    public override Pawnshop Update(Pawnshop entity) {
        return Context.Update(entity).Entity;
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


}