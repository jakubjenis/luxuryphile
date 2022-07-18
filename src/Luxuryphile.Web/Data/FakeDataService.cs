using Luxuryphile.Api.Contract;

namespace Luxuryphile.Web.Data;

public class FakeDataService
{
    private readonly List<ContractDetail> _contracts = Enumerable
            .Range(1, 10)
            .Select(i => FakeData.CreateFakeContractDetail(i))
            .ToList();

    private readonly List<ClientDetail> _clients = new()
    {
        new ClientDetail(
            Guid.NewGuid(),
            "Jakub",
            "Jenis",
            "jakubjenis@gmail.com",
            "234827348",
            "Pod Horou 12, Praha 5",
            new DateOnly(1990, 12, 3),
            "SJ2837480",
            null),
        new ClientDetail(
            Guid.NewGuid(),
            "Jakub",
            "Jenis",
            "jakubjenis@gmail.com",
            "234827348",
            "Pod Horou 12, Praha 5",
            new DateOnly(1990, 12, 3),
            "SJ2837480",
            null),
        new ClientDetail(
            Guid.NewGuid(),
            "Jakub",
            "Jenis",
            "jakubjenis@gmail.com",
            "234827348",
            "Pod Horou 12, Praha 5",
            new DateOnly(1990, 12, 3),
            "SJ2837480",
            null)
    };


    public async Task<ClientRow[]> GetClients(string? name = null)
    {
        return _clients
            .Select(o => new ClientRow(o.Id,
                o.FirstName,
                o.LastName))
            .Where(i =>
                name == null ||
                i.LastName.ToLower().Contains(name.ToLower()))
            .OrderBy(o => o.LastName)
            .ToArray();
    }
    
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

    public  Task<ContractDetail?> GetContract(Guid id)
    {
        return Task.FromResult(_contracts.FirstOrDefault(o => o.Id == id));
    }
    
    public Task<Guid> CreateContract(CreateContractRequest request)
    {
        throw new NotImplementedException();
        // var contract = new ContractDetail(Guid.NewGuid(),
        //     _contracts.Max(x => x.Number) + 1,
        //     DateTime.Now, request.Provision, new ClientDetail(
        //         request.Seller.FirstName,
        //         request.Seller.LastName,
        //         request.Seller.Email,
        //         request.Seller.Phone,
        //         request.Seller.Address,
        //         request.Seller.DateOfBirth,
        //         request.Seller.DocumentNumber,
        //         null),
        //     request.Items);
        //
        // _contracts.Add(contract);
        // return Task.FromResult(contract.Id);
    }
}