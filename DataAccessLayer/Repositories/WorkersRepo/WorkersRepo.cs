using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.WorkersRepo;

public class WorkersRepo : EfRepositoryBase<Worker>, IWorkersRepo {
    public WorkersRepo(PawnshopDbContext context) : base(context) { }

    public override async Task<Worker?> GetElementById(int id) {
        return await Context.Workers.SingleOrDefaultAsync(w => w.Id == id);
    }

    public override async Task<Worker?> GetElementById(int id, string[] related) {
        var query = Context.Workers.Where(w => w.Id == id);

        query = ProcessingRelated(query, related);

        return await query.SingleOrDefaultAsync();
    }

    public override async Task<List<Worker>> GetAll(int limit, int offset, string[] related) {
        var query = Context.Workers.AsQueryable();

        query = ProcessingRelated(query, related).AsNoTracking();

        var list = await query
            .Skip(offset)
            .Take(limit)
            .ToListAsync();

        foreach (var worker in list) {
            if(worker.Position != null) worker.Position.Workers.Clear();
        }

        return list;
    }

    protected override IQueryable<Worker> ProcessingRelated(IQueryable<Worker> filtered, string[] relations) {
        foreach (var rel in relations) {
            if (rel == "Operations")
                filtered = filtered.Include(w => w.Operations);
            else if (rel == "Mades")
                filtered = filtered.Include(w => w.Mades);
            else if (rel == "Position")
                filtered = filtered.Include(w => w.Position);
            else if (rel == "Pawnshop")
                filtered = filtered.Include(w => w.Pawnshop);
        }

        return filtered;
    }

    public override Worker Update(Worker entity) {
        var elem = Context.Workers.AsNoTracking().Single(w => w.Id == entity.Id);

        entity.Password = elem.Password;
        entity.Salt = elem.Salt;

        return Context.Workers.Update(entity).Entity;
    }

    public override async Task<Worker> Add(Worker entity) {
        return (await Context.AddAsync(entity)).Entity;
    }

    public override async Task<bool> Delete(int id) {
        var el = await GetElementById(id);

        if (el == null) return false;

        return Context.Remove(el).IsKeySet;
    }

    public override async Task<List<Worker>> SearchByAttribute(string attribute, string query, int limit, int offset) {
        if (attribute == "Name") {
            return await Context.Workers
                .Where(w => (w.FirstName + " " + w.SecondName + " " + w.ThirdName).Contains(query))
                .Include(w => w.Position)
                .Include(w => w.Pawnshop)
                .ToListAsync();
        }

        if (attribute == "Position") {
            return await Context.Workers
                .Include(w => w.Position)
                .Include(w => w.Pawnshop)
                .Where(w => w.Position.Name.Contains(query))
                .ToListAsync();
        }

        return new List<Worker>();
    }


    public override async Task<List<Worker>> SortByAttribute(string attribute, int limit, int offset) {
        return await Context.Workers.OrderByDescending(w => w.Salary)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();
    }

    public async Task<WorkerPosition> AddPosition(WorkerPosition workerPosition) {
        return (await Context.WorkerPositions.AddAsync(workerPosition)).Entity;
    }

    public async Task<List<WorkerPosition>> GetPositions() {
        return await Context.WorkerPositions.AsNoTracking().ToListAsync();
    }

    public async Task<WorkerPosition?> GetPosition(int id) {
        return await Context.WorkerPositions.AsNoTracking().SingleOrDefaultAsync(w => w.Id == id);
    }
}