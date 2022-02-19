namespace Luxuryphile.Fakturoid.Data;

public class InvoiceItem
{
    public InvoiceItem(string name, decimal quantity, decimal unitPrice, decimal vatRate)
    {
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
        VatRate = vatRate;
    }
    
    public string Name { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public string UnitName { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public decimal VatRate { get; set; }
    
    public static InvoiceItem CreateItem(string name, decimal quantity, decimal unitPrice, bool newItem)
    {
        var vatRate = newItem ? 21 : 0;
        return new InvoiceItem(name, quantity, unitPrice, vatRate);
    }
        
    public static InvoiceItem CreatePostItem(decimal unitPrice)
    {
        return new InvoiceItem("Poštovné", 1, unitPrice, 21);
    }
}