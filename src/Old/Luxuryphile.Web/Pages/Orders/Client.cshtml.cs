using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luxuryphile.CORE;
using Luxuryphile.CORE.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoldItem = Luxuryphile.CORE.Database.SoldItem;

namespace Luxuryphile.Web.Pages.Orders
{
    public class ClientModel : PageModel
    {
        private readonly FakturoidClient _fakturoidClient;
        private readonly LuxuryContext _context;

        [BindProperty]
        public OrderModel Order { get; set; }

        public ClientModel( FakturoidClient fakturoidClient, LuxuryContext context)
        {
            _fakturoidClient = fakturoidClient;
            _context = context;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var order = await _context.GetOrder(id);
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
            
            var orders = await _context.Orders.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _fakturoidClient.CreateSubject(Customer.Name, Customer.Email, Customer.Street, Customer.City, Customer.ZipCode, Customer.Country);
            
            var order = await _context.GetOrder(id);
            if (order == null) return NotFound();
            
            order.AddressCity = Order.City;
            order.AddressCountry = Order.Country;
            order.AddressStreet = Order.Street;
            order.AddressZipCode = Order.ZipCode;
            await _context.SaveChangesAsync();
            
            var invoiceId = await _fakturoidClient.CreateInvoice(10626301,  order.SoldItems, true);

            var invoice = await _fakturoidClient.GetInvoice(invoiceId);
            return RedirectPermanent(invoice.public_html_url);
        }    
    }
}