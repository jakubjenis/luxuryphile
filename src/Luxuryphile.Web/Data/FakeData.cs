using Luxuryphile.Core.DTO;

namespace Luxuryphile.Web.Data;

public static class FakeData
{
    public static ContractDto CreateFakeContract()
    {
        return new ContractDto(
            Id: Guid.NewGuid(),
            DateCreated: DateTime.UtcNow,
            Seller: "Jakub Jenis",
            Number: 123456,
            Provision: 15);
    }
}