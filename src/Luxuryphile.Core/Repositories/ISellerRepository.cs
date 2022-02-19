using Luxuryphile.Core.Models.Contract;

namespace Luxuryphile.Core.Repositories;

public interface ISellerRepository
{
    public Task<Seller> GetSellerById(Guid id);
}