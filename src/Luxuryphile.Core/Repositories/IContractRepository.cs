using Luxuryphile.Core.Models.Contract;

namespace Luxuryphile.Core.Repositories;

public interface IContractRepository
{
    public Task Add(Contract contract);
    
    public Task<Contract> GetById(Guid id);
    
    public Task<int> GetNextAvailableContractNumber();
}