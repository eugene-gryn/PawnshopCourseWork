using DataAccessLayer.Context;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.OperationsRepo;

public class OperationsRepo : EfRepositoryBase<Operation>, IOperationRepo {
    public OperationsRepo(PawnshopDbContext context) : base(context) { }

    public async Task<OperationType> AddOperationType(OperationType operationType) {
        return (await Context.OperationTypes.AddAsync(operationType)).Entity;
    }

    public async Task<List<OperationType>> GetOperationTypeList() {
        return await Context.OperationTypes.ToListAsync();
    }

    public async Task<OperationType?> GetOperationType(int id) {
        return await Context.OperationTypes.SingleOrDefaultAsync(o => o.Id == id);
    }

    public override async Task<Operation?> GetElementById(int id) {
        return await Context.Operations.SingleOrDefaultAsync(o => o.Id == id);
    }

    public override async Task<Operation?> GetElementById(int id, string[] related) {
        var query = Context.Operations.Where(o => o.Id == id);

        query = ProcessingRelated(query, related);

        return await query.SingleOrDefaultAsync();
    }

    public override async Task<List<Operation>> GetAll(int limit, int offset, string[] related) {
        var query = Context.Operations.Skip(offset).Take(limit);

        query = ProcessingRelated(query, related);

        return await query.ToListAsync();
    }

    protected override IQueryable<Operation> ProcessingRelated(IQueryable<Operation> filtered, string[] relations) {
        foreach (var rel in relations)
            if (rel == "Worker")
                filtered = filtered.Include(o => o.Worker);
            else if (rel == "Pawnshop")
                filtered = filtered.Include(o => o.Pawnshop);
            else if (rel == "Customer") filtered = filtered.Include(o => o.Customer);

        return filtered;
    }

    public override Operation Update(Operation entity) {
        return Context.Update(entity).Entity;
    }

    public override async Task<Operation> Add(Operation entity) {
        entity.Id = 0;

        return (await Context.Operations.AddAsync(entity)).Entity;
    }

    public override async Task<bool> Delete(int id) {
        var el = await GetElementById(id);

        if (el == null) return false;

        return Context.Remove(el).IsKeySet;
    }

    public override async Task<List<Operation>>
        SearchByAttribute(string attribute, string query, int limit, int offset) {
        var operations = new List<Operation>();

        if (attribute == "Created") {
            var date = DateTime.Parse(query);

            operations = await Context.Operations.Where(o => o.Created == date)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }
        else if (attribute == "Description") {
            operations = await Context.Operations.Where(o => o.Description != null && o.Description.Contains(query))
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
        }
        else if (attribute == "OperationType") {
            var list = await Context.OperationTypes.Where(ot => ot.Name.Contains(query)).Include(ot => ot.Operations)
                .ToListAsync();

            foreach (var type in list) operations.AddRange(type.Operations);
            operations = operations
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        return operations;
    }

    public override async Task<List<Operation>> SortByAttribute(string attribute, int limit, int offset) {
        var operations = new List<Operation>();

        if (attribute == "Created")
            operations = await Context.Operations.OrderBy(o => o.Created)
                .ToListAsync();

        return operations;
    }
}