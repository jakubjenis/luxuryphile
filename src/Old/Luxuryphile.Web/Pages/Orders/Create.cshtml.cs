﻿using System.Collections.Generic;
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
    public class CreateModel : PageModel
    {
        private readonly FakturoidClient _fakturoidClient;
        private readonly LuxuryContext _context;

        [BindProperty]
        public OrderModel Order { get; set; }
        
        [BindProperty]
        public List<SoldItem> SoldItems { get; set; }

        [BindProperty]
        public int AccountId { get; set; }
        
        public string Currency { get; set; }
        
        public List<Customer> Clients { get; set; }
        
        public List<Account> Accounts { get; set; }

        public CreateModel( FakturoidClient fakturoidClient, LuxuryContext context)
        {
            _fakturoidClient = fakturoidClient;
            _context = context;
            SoldItems = new List<SoldItem>();
        }

        public async Task OnGet()
        {
            var orders = await _context.Orders.ToListAsync();
            
            Clients = await _fakturoidClient.GetSubjects();
            Accounts = await _fakturoidClient.GetAccounts();
            Currency = "CZK";

            Order = new OrderModel
            {
                Name = "Fero Hora",
                Street = "Pod Horou 19",
                City = "Prievidza",
                Country = "CZK",
                Email = "fero@hora.cz",
                ZipCode = "11000"
            };
            SoldItems.Add(SoldItem.CreateItem("Hodinky rolex zlaté", 1, 253499, false));
            SoldItems.Add(SoldItem.CreateItem("Kabelka Louis Vuitton, růžová", 1, 72199, true));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var order = new Order
            {
                State = OrderState.Created,
                InvoiceId =  null,
                ClientName = Order.Name,
                ClientEmail = Order.Email,
                AddressCity = Order.City,
                AddressCountry = Order.Country,
                AddressStreet = Order.Street,
                AddressZipCode = Order.ZipCode,
                SoldItems = SoldItems
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }    
    }
}