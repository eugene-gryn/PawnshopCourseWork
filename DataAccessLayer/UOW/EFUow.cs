using DataAccessLayer.Context;
using DataAccessLayer.Repositories.CustomersRepo;
using DataAccessLayer.Repositories.MakesRepo;
using DataAccessLayer.Repositories.OperationsRepo;
using DataAccessLayer.Repositories.PawnshopsRepo;
using DataAccessLayer.Repositories.WorkersRepo;

namespace DataAccessLayer.UOW;

public class EfUow : IUow {
    private readonly PawnshopDbContext _context;

    public EfUow(PawnshopDbContext context) {
        _context = context;
    }

    private ICustomerRepo? _customers;
    private IMakesRepo? _makes;
    private IOperationRepo? _operations;
    private IPawnshopRepo? _pawnshops;
    private IWorkersRepo? _workers;

    public ICustomerRepo Customers => _customers ??= new CustomerRepo(_context);
    public IMakesRepo Makes => _makes ??= new MakesRepo(_context);
    public IOperationRepo Operations => _operations ??= new OperationsRepo(_context);
    public IPawnshopRepo Pawnshops => _pawnshops ??= new PawnshopRepo(_context);
    public IWorkersRepo Workers => _workers ??= new WorkersRepo(_context);

    public void Save() {
        _context.SaveChanges();
    }

    public async Task SaveAsync() {
        await _context.SaveChangesAsync();
    }
}