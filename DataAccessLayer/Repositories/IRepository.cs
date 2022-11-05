using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public interface IRepository<T> {
    public Task<T?> GetElementById(int id);
    public Task<List<T>> GetAll(int limit, int offset);
    public int Count();

    public T Update(T entity);
    public Task<T> Add(T entity);

    // Unsafe for optimization methods
    public IQueryable<T> ReadAsQuery();

}