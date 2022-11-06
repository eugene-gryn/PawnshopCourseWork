using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public abstract class EfRepositoryBase<T> : IRepository<T> where T : class {
    protected EfRepositoryBase(PawnshopDbContext context) {
        Context = context;
    }

    protected PawnshopDbContext Context { get; set; }

    public abstract Task<T?> GetElementById(int id);
    public abstract Task<T?> GetElementById(int id, string[] related);
    public abstract Task<List<T>> GetAll(int limit, int offset, string[] related);

    public virtual async Task<List<T>> GetAll(int limit, int offset) {
        return await Context.Set<T>().Skip(offset).Take(limit).ToListAsync();
    }

    protected abstract IQueryable<T> ProcessingRelated(IQueryable<T> filtered, string[] relations);

    public abstract T Update(T entity);
    public abstract Task<T> Add(T entity);
    public abstract Task<bool> Delete(int id);
    public abstract Task<List<T>> SearchByAttribute(string attribute, string query, int limit, int offset);
    public abstract Task<List<T>> SortByAttribute(string attribute, int limit, int offset);

    public virtual IQueryable<T> ReadAsQuery() {
        return Context.Set<T>().AsSplitQuery();
    }
}