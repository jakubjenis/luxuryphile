namespace Luxuryphile.Core.Models.Contract;

public class Contract
{
    public Contract(DateTime utcNow, Seller seller, int contractNumber, decimal provision, List<ContractItem> itemsToSell)
    {
        Id = Guid.NewGuid();
        Seller = seller;
        ContractNumber = contractNumber;
        Provision = provision;
        ItemsToSell = itemsToSell;

        if (utcNow.Kind != DateTimeKind.Utc)
            throw new InvalidOperationException($"UtcNow.Kind is not UTC, but {utcNow.Kind}");
        DateCreated = utcNow;
    }
    
    public Guid Id { get; }

    public Seller Seller { get; }
    public int ContractNumber { get; }

    public DateTime DateCreated { get; }
    
    public decimal Provision { get; }

    public List<ContractItem> ItemsToSell { get; }

    public Task SignByHoa()
    {
        return Task.CompletedTask;
    }
    
    public Task SignBySeller()
    {
        return Task.CompletedTask;
    }
}