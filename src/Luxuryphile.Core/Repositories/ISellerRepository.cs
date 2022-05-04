using Luxuryphile.Core.Contracts;

namespace Luxuryphile.Core.Repositories;

public interface ISellerRepository
{
    public Task<Seller> GetSellerById(Guid id);
}