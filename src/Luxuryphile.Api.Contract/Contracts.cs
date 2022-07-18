namespace Luxuryphile.Api.Contract;

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
    ClientDetail Seller,
    SoldItem[] Items);

public record CreateContractRequest(
    CreateSellerRequest Seller,
    SoldItem[] Items,
    decimal Provision);

public record CreateSellerRequest(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Address,
    DateOnly DateOfBirth,
    string DocumentNumber);


