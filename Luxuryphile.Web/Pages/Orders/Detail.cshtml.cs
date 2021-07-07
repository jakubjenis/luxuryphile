using System.Threading.Tasks;
using Luxuryphile.CORE;
using Luxuryphile.CORE.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Luxuryphile.Web.Pages.Orders
{
    public class DetailModel : PageModel
    {
        private readonly FakturoidClient _fakturoidClient;
        private readonly LuxuryContext _context;

        public OrderModel Order { get; set; }
        
        public DetailModel( FakturoidClient fakturoidClient, LuxuryContext context)
        {
            _fakturoidClient = fakturoidClient;
            _context = context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var order = await _context.Orders
                .Include(o => o.SoldItems)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return NotFound();

            Order = new OrderModel
            {
                Id = order.Id,
                Name = order.ClientName,
                State = order.State,
                City = order.AddressCity,
                Country = order.AddressCountry,
                Email = order.ClientEmail,
                Street = order.AddressStreet,
                ZipCode = order.AddressZipCode,
                SoldItems = order.SoldItems
            };
            
            return Page();
        }
        
        public async Task<ActionResult> OnGetDownloadInvoice(int id)
        {
            var pdf = await _fakturoidClient.DownloadInvoice(id);
            var fileStreamResult = new FileContentResult(pdf, "application/pdf");
            fileStreamResult.FileDownloadName = "Faktura.pdf";
            return fileStreamResult;
        }
        
        public async Task<ActionResult> OnGetMarkAsPaid(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
            order.State = OrderState.Paid;
            await _context.SaveChangesAsync();
            return RedirectToPage("Detail");
        }
        
        public async Task<ActionResult> OnGetCancel(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
            order.State = OrderState.Cancelled;
            await _context.SaveChangesAsync();
            return RedirectToPage("Detail");
        }
        
        public async Task<ActionResult> OnGetMarkAsDelivered(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
            order.State = OrderState.Delivered;
            await _context.SaveChangesAsync();
            return RedirectToPage("Detail");
        }
    }
}