namespace Luxuryphile.Core.DTO;

public record CreateContractRequest(
    CreateSellerRequest Seller,
    decimal Provision);

public record CreateSellerRequest(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Address,
    DateOnly DateOfBirth,
    string DocumentNumber);

public record ContractRow(Guid Id,
    int Number, 
    DateTime DateCreated, 
    decimal Provision,
    string Seller);

public record ContractDetail(
    Guid Id,
    int Number,
    DateTime DateCreated,
    decimal Provision,
    SellerDetail Seller);

public record SellerDetail(
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