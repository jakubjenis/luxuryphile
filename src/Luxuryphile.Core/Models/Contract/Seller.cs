using Luxuryphile.Core.Models.Orders;

namespace Luxuryphile.Core.Models.Contract;

public class Seller
{
    public Seller(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
    }
    
    public Guid Id { get;}

    public string FirstName { get; }

    public string LastName { get; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    /// <summary>
    /// Passport / ID number
    /// </summary>
    public string? DocumentNumber { get; set; }

    public List<BankAccount> BankAccounts { get; set; } = new();
}