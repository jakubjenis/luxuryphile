namespace Luxuryphile.Fakturoid.Data;

public class Customer
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;
    public int Id { get; set; }
}