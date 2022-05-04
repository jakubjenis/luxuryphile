namespace Luxuryphile.Core.Repositories;

public interface IContractRepository
{
    public Task Add(Contracts.Contract contract);
    
    public Task<Contracts.Contract> GetById(Guid id);
    
    public Task<int> GetNextAvailableContractNumber();
}