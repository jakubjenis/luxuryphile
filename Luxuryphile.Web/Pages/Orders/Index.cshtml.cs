using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luxuryphile.CORE.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Luxuryphile.Web.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LuxuryContext _context;

        public List<OrderModel> Orders { get; set; }
        
        public IndexModel(ILogger<IndexModel> logger, LuxuryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            Orders = await _context.Orders.Select(o => new OrderModel
            {
                Id = o.Id,
                Name = o.ClientName,
                State = o.State,
                City = o.AddressCity,
                Country = o.AddressCountry,
                Email = o.ClientEmail,
                Street = o.AddressStreet,
                ZipCode = o.AddressZipCode
            }).ToListAsync();
        }
    }
}