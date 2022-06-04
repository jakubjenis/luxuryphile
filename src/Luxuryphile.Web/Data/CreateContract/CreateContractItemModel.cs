namespace Luxuryphile.Web.Data.CreateContract
{
    public class CreateContractItemModel
    {
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Currency { get; set; } = "CZK";

        public string Faults { get; set; } = string.Empty;
    }
}
