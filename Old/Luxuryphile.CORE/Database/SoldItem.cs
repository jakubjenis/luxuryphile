namespace Luxuryphile.CORE.Database
{
    public class SoldItem
    {
        public SoldItem(string name, decimal quantity, decimal unitPrice, decimal vatRate, string unitName = "ks")
            : this(name, quantity, unitPrice)
        {
            VatRateRate = vatRate;
        }
        
        public SoldItem(string name, decimal quantity, decimal unitPrice)
            : this()
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public SoldItem()
        {
            VatRateRate = 21;
            UnitName = "ks";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public string UnitName { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Price => UnitPrice * Quantity;
        public decimal VatRateRate { get; set; }

        public static SoldItem CreateItem(string name, decimal quantity, decimal unitPrice, bool newItem)
        {
            var vatRate = newItem ? 21 : 0;
            return new SoldItem(name, quantity, unitPrice, vatRate);
        }
        
        public static SoldItem CreatePostItem(decimal unitPrice)
        {
            return new SoldItem("Poštovné", 1, unitPrice, 21);
        }
    }
}