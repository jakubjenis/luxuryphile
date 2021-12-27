using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altairis.Fakturoid.Client;
using Luxuryphile.CORE.Database;
using Luxuryphile.Web.Models;

namespace Luxuryphile.CORE
{
    public class FakturoidClient
    {
        private readonly FakturoidContext _context;

        public FakturoidClient()
        {
            _context = new FakturoidContext("jakubjenis1", "j.akubjenis@gmail.com",
                "fd0896cba3fca0207e129a432a02af72acab36c0", "luxuryphile (jakubjenis@gmail.com)");
        }

        // public int SearchSubject(string query)
        // {
        //     var subjectId = _context.Subjects.Search(query);
        //     return subjectId;
        // }
        
        public async Task<int> CreateSubject(string name, string email)
        {
            var subjectId = await _context.Subjects.CreateAsync(new JsonSubject
            {
                name = name,
                email = email,
            });
            return subjectId;
        }
        
        public async Task<List<Customer>> GetSubjects()
        {
            var subjects = await _context.Subjects.SelectAsync();
            return subjects.Select(o => new Customer
            {
                Id = o.id,
                Name = o.name,
                Email = o.email,
                Street = o.street,
                City = o.city,
                Country = o.country,
                ZipCode = o.zip
            }).ToList();
        }
        
        public async Task<List<Account>> GetAccounts()
        {
            var accounts = await _context.BankAccounts.SelectAsync();
            return accounts
                .Where(o => !string.IsNullOrEmpty(o.number))
                .Select(o => new Account
            {
                Id = o.id,
                Name = o.name,
                Currency = o.currency,
                Number = o.number,
                 
            }).ToList();
        }
        
        public async Task<int> CreateSubject(string name, string email, string street, string city, string zip, string country)
        {
            var subjectId = await _context.Subjects.CreateAsync(new JsonSubject
            {
                name = name,
                street = street,
                city = city,
                zip = zip,
                country = country,
                email = email
            });
            return subjectId;
        }

        public async Task<int> CreateInvoice(int subjectId, List<SoldItem> soldItems, bool proforma)
        {
            var newInvoice = new JsonInvoice
            {
                subject_id = subjectId,
                lines = new List<JsonInvoiceLine>(),
                proforma = proforma
            };
            foreach (var soldItem in soldItems)
            {
                newInvoice.lines.Add(new JsonInvoiceLine
                {
                    name = soldItem.Name,
                    quantity = soldItem.Quantity,
                    unit_name = soldItem.UnitName,
                    unit_price = soldItem.UnitPrice,
                    vat_rate = soldItem.VatRateRate
                });
            }

            var newInvoiceId = await _context.Invoices.CreateAsync(newInvoice);
            return newInvoiceId;
        }

        public async Task<JsonInvoice> GetInvoice(int invoiceId)
        {
            return await _context.Invoices.SelectSingleAsync(invoiceId);
        }

        public async Task<byte[]> DownloadInvoice(int id)
        {
            return await _context.Invoices.DownloadInvoicePDF(id);
        }
    }
}