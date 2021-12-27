namespace Luxuryphile.Web.Models
{
    public class Customer
    {
        public Customer()
        {
        }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        
        public string Country { get; set; }
        public int Id { get; set; }

        public string AddressOneLine =>
            City != null || Street != null || ZipCode != null 
                ? $"{Street}, {City}, {ZipCode}"
                : string.Empty;
    }
}