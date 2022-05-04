using Luxuryphile.Core.DTO;
using Luxuryphile.Core.Orders;

namespace Luxuryphile.Web.Data;

public class FakeDataService
{
    public async Task<Order[]> GetOrders()
    {
        return new Order[] { };
    }

    public async Task<ContractDto[]> GetContracts()
    {
        return Enumerable
            .Range(1, 100)
            .Select(i => FakeData.CreateFakeContract())
            .ToArray();
    }
}