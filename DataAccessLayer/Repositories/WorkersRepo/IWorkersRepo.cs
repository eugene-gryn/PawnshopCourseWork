using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.WorkersRepo;

public interface IWorkersRepo : IRepository<Worker> {
    public Task<WorkerPosition> AddPosition(WorkerPosition workerPosition);
    public Task<List<WorkerPosition>> GetPositions();
    public Task<WorkerPosition?> GetPosition(int id);

}