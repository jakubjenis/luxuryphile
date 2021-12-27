using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Luxuryphile.CORE.Database
{
    public class LuxuryContext : DbContext
    {
        public LuxuryContext()
        {
        }
        
        public LuxuryContext(DbContextOptions<LuxuryContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<SoldItem> SoldItems { get; set; }

        public async Task<Order> GetOrder(int id)
        {
            var order = await Orders
                .Include(o => o.SoldItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            return order;
        }
    }
}