namespace Luxuryphile.Core.Models.Orders;

public class Order
{
    public int Id { get; set; }
    
    public OrderState State { get; set; }
    
    public string ClientName { get; set; }
    
    public string ClientEmail { get; set; }
    
    public string AddressStreet { get; set; }
    
    public string AddressCity { get; set; }
    public string AddressZipCode { get; set; }
    
    public string AddressCountry { get; set; }
    
    public List<SoldItem> SoldItems { get; set; }
    
    public int? InvoiceIdProforma { get; set; }
    
    public int? InvoiceId { get; set; }

    public string AddressOneLine =>
        AddressCity != null || AddressStreet != null || AddressZipCode != null
            ? $"{AddressStreet}, {AddressCity}, {AddressZipCode}"
            : string.Empty;
}