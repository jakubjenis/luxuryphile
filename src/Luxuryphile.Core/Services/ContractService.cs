using Luxuryphile.Core.Contracts;
using Luxuryphile.Core.Repositories;

namespace Luxuryphile.Core.Services;

public class ContractService
{
    private readonly ITimeService _timeService;
    private readonly ISellerRepository _sellerRepository;
    private readonly IContractRepository _contractRepository;

    public ContractService(ITimeService timeService, ISellerRepository sellerRepository, IContractRepository contractRepository)
    {
        _timeService = timeService;
        _sellerRepository = sellerRepository;
        _contractRepository = contractRepository;
    }
    
    public async Task<Contract> CreateContract(Guid sellerId, decimal provision, List<ContractItem> itemsToSell)
    {
        var seller = await _sellerRepository.GetSellerById(sellerId);
        var contractNumber = await _contractRepository.GetNextAvailableContractNumber();

        var utcNow = _timeService.GetUtcNow();
        var contract = new Contract(utcNow, seller, contractNumber, provision, itemsToSell);
        await contract.SignByHoa();

        await _contractRepository.Add(contract);
        
        return contract;
    }
    
    public async Task<Contract> SignContractBySeller(Guid contractId)
    {
        var contract = await _contractRepository.GetById(contractId);
        await contract.SignBySeller();

        return contract;
    }
}