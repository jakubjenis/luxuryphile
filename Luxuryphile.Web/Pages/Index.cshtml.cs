using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Luxuryphile.CORE;
using Luxuryphile.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Luxuryphile.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FakturoidClient _fakturoidClient;

        [BindProperty]
        public Customer Customer { get; set; }
        
        [BindProperty]
        public List<SoldItem> SoldItems { get; set; }

        [BindProperty]
        public int AccountId { get; set; }
        
        public string Currency { get; set; }
        
        public List<Customer> Customers { get; set; }
        
        public List<Account> Accounts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, FakturoidClient fakturoidClient)
        {
            _logger = logger;
            _fakturoidClient = fakturoidClient;
            SoldItems = new List<SoldItem>();
        }

        public async Task OnGet()
        {
            Customers = await _fakturoidClient.GetSubjects();
            Accounts = await _fakturoidClient.GetAccounts();
            Currency = "CZK";
            
            SoldItems.Add(SoldItem.CreateItem("Hodinky rolex zlaté", 1, 253499, false));
            SoldItems.Add(SoldItem.CreateItem("Kabelka Louis Vuitton, růžová", 1, 72199, true));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _fakturoidClient.CreateSubject(Customer.Name, Customer.Email, Customer.Street, Customer.City, Customer.ZipCode, Customer.Country);

            var validSoldItems = SoldItems.Where(o => o.Quantity > 0).ToList();
            await _fakturoidClient.CreateInvoice(10626301, validSoldItems, true);
            
            return RedirectToPage("./Index");
        }
        
        public async Task<ActionResult> OnPostDownloadFile()
        {
            var pdf = await _fakturoidClient.DownloadInvoice(16270662);
            var fileStreamResult = new FileContentResult(pdf, "application/pdf");
            fileStreamResult.FileDownloadName = "Faktura.pdf";
            return fileStreamResult;
        }
    }
}