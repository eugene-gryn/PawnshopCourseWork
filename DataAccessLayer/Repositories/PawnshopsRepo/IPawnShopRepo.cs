using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.PawnshopsRepo;

public interface IPawnshopRepo : IRepository<Pawnshop> {
    public Task<List<City>> GetCityAsync();

    public Task<City?> GetCityById(int id);
    public Task<City> AddCity(City city);
}