using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public interface IRepository<T> {

    public Task<T?> GetElementById(int id);
    public Task<T?> GetElementById(int id, string[] related);
    public Task<List<T>> GetAll(int limit, int offset, string[] related);
    public Task<List<T>> GetAll(int limit, int offset);
    public T Update(T entity);
    public Task<T> Add(T entity);
    public Task<bool> Delete(int id);

    public Task<List<T>> SearchByAttribute(string attribute, string query, int limit, int offset);
    public Task<List<T>> SortByAttribute(string attribute, int limit, int offset);

    // Unsafe for optimization methods
    public IQueryable<T> ReadAsQuery();
}