using Luxuryphile.Core.DTO;

namespace Luxuryphile.Web.Data;

public class FakeDataService
{
    private List<ContractDetail> _contracts = Enumerable
            .Range(1, 10)
            .Select(i => FakeData.CreateFakeContractDetail(i))
            .ToList();

    public async Task<ContractRow[]> GetContracts(string? name = null)
    {
        return _contracts
            .Select(o => new ContractRow(o.Id,
                o.Number,
                o.DateCreated,
                o.Provision,
                o.Seller.FullName))
            .Where(i =>
                name == null ||
                i.Number.ToString().ToLower().Contains(name.ToLower()) ||
                i.Seller.ToLower().Contains(name.ToLower()))
            .OrderByDescending(o => o.DateCreated)
            .ToArray();
    }
    public Task<Guid> CreateContract(CreateContractRequest request)
    {
        var contract = new ContractDetail(Guid.NewGuid(),
            _contracts.Max(x => x.Number) + 1,
            DateTime.Now, request.Provision, new SellerDetail(
                request.Seller.FirstName,
                request.Seller.LastName,
                request.Seller.Email,
                request.Seller.Phone,
                request.Seller.Address,
                request.Seller.DateOfBirth,
                request.Seller.DocumentNumber,
                null));

        _contracts.Add(contract);
        return Task.FromResult(contract.Id);
    }
}