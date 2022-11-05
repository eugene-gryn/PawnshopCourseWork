﻿using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public abstract class EfRepositoryBase<T>: IRepository<T> where T : class {
    protected EfRepositoryBase(PawnshopDbContext context) {
        Context = context;
    }

    protected PawnshopDbContext Context { get; set; }

    public abstract Task<T?> GetElementById(int id);

    public virtual async Task<List<T>> GetAll(int limit, int offset) {
        return await Context.Set<T>().Skip(offset).Take(limit).ToListAsync();
    }

    public virtual T Update(T entity) {
        throw new NotImplementedException();
    }

    public virtual Task<T> Add(T entity) {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Delete(int id) {
        throw new NotImplementedException();
    }

    public virtual async Task<List<T>> SearchByAttribute(string attribute, string query, int limit, int offset) {
        throw new NotImplementedException();
    }

    public virtual async Task<List<T>> SortByAttribute(string attribute, int limit, int offset) {
        throw new NotImplementedException();
    }

    public virtual IQueryable<T> ReadAsQuery() {
        return Context.Set<T>().AsSplitQuery();
    }
}