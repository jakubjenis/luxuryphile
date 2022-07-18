namespace Luxuryphile.Api.Contract;

public record SoldItem(
    string Description,
    decimal Price,
    string Currency, 
    string Faults)
{
    public string FormattedPrice => $"{Price} {Currency}";
}
