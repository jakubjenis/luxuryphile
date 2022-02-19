using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.Fakturoid.Client;
using Luxuryphile.Fakturoid.Data;
using Xunit;

namespace Luxuryphile.Fakturoid.Tests
{
    public class FakturoidClientTests
    {
        [Fact]
        public async Task CreateInvoice()
        {
            var client = new FakturoidClient();

            var items = new List<InvoiceItem>
            {
                InvoiceItem.CreateItem("Hodinky rolex zlaté", 1, 253499, false),
                InvoiceItem.CreateItem("Kabelka Luis Vitton, růžová", 1, 72199, true),
                InvoiceItem.CreatePostItem(123.99M)
            };
            await client.CreateInvoice(10625976, items, false);
        }
        
        [Fact]
        public  async Task CreateSubject_Simple()
        {
            var client = new FakturoidClient();
            await client.CreateSubject("Janko Hraško", "janko@hrasko.com");
        }
        
        [Fact]
        public async Task CreateSubject_WithAddress()
        {
            var client = new FakturoidClient();
            await client.CreateSubject("Janko Hraško", "janko@hrasko.com", "Pod horou 19", "Hora", "12345", "CZ");
        }

        [Fact]
        public async Task Delete_All()
        {
             var context = new FakturoidContext("jakubjenis1", "j.akubjenis@gmail.com",
                 "fd0896cba3fca0207e129a432a02af72acab36c0", "luxuryphile (jakubjenis@gmail.com)");

            // Get account info
            var info = context.GetAccountInfo();


            var invoices = context.Invoices.Select();
            foreach (var invoice in invoices) { 
                context.Invoices.Delete(invoice.id);
            }

            var subjects = context.Subjects.Select();

            foreach (var subject in subjects) { 
                context.Subjects.Delete(subject.id);
            }
        }
    }
}