namespace Luxuryphile.Api.Contract;

public record ClientRow(Guid Id,
    string FirstName,
    string LastName)
{
    public string FullName => $"{FirstName} {LastName}";
}

public record ClientDetail(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Address,
    DateOnly DateOfBirth,
    string DocumentNumber,
    List<BankAccount>? BankAccounts)
{
    public string FullName => $"{FirstName} {LastName}";
}

public record BankAccount(
    string BBAN,
    string Currency);