namespace Luxuryphile.Core.Models.Contract
{
    public class ContractItem
    {
        public ContractItem(string name, decimal quantity, decimal unitPrice, string currency, string unitName = "ks")
        {
            Id = Guid.NewGuid();
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Currency = currency;
            UnitName = unitName;
        }
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string UnitName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Currency { get; }

        public decimal Price => UnitPrice * Quantity;
    }
}