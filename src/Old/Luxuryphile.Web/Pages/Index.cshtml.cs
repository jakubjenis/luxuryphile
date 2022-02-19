using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luxuryphile.CORE;
using Luxuryphile.CORE.Database;
using Luxuryphile.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Luxuryphile.Web.Pages
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

        public async Task<IActionResult> OnGet()
        {
            return RedirectToPage("Orders/Index");
        }
    }
}