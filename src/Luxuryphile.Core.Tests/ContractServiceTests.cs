using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using FluentAssertions;
using Luxuryphile.Core.Contracts;
using Luxuryphile.Core.Repositories;
using Luxuryphile.Core.Services;
using Moq;
using Xunit;

namespace Luxuryphile.Core.Tests;

public class ContractServiceTests
{
    [Fact]
    public async Task CreateContract()
    {
        var sellerRepository = new Mock<ISellerRepository>(MockBehavior.Strict);
        var contractRepository = new Mock<IContractRepository>(MockBehavior.Strict);
        var timeService = new Mock<ITimeService>(MockBehavior.Strict);

        var sellerId = new Guid("6855ed7b-a8e6-4ef8-9c0c-2e9bd36f0177");
        var utcNow = DateTime.UtcNow;

        timeService
            .Setup(o => o.GetUtcNow())
            .Returns(utcNow);
        
        sellerRepository
            .Setup(o => o.GetSellerById(sellerId))
            .ReturnsAsync(() => new Seller("Filoména", "Márnotratná"));

        contractRepository
            .Setup(o => o.GetNextAvailableContractNumber())
            .ReturnsAsync(12345);

        contractRepository
            .Setup(o => o.Add(It.IsAny<Contracts.Contract>()))
            .Returns<Contracts.Contract>(_ => Task.CompletedTask);
       
        var soldItems = new List<ContractItem>
        {
            new("Rolex 2020 pre-owned Submariner 40mm", 1, 1667620, "czk"),
            new("Small Dior Book Tote", 2, 3200, "eur")
        };
        
        var service = new ContractService(timeService.Object, sellerRepository.Object, contractRepository.Object);
        var contract = await service.CreateContract(sellerId, 15, soldItems);

        contract.Id.Should().NotBeEmpty();
        contract.Provision.Should().Be(15);
        contract.Seller.FirstName.Should().Be("Filoména");
        contract.Seller.LastName.Should().Be("Márnotratná");
        contract.Number.Should().Be(12345);
        contract.DateCreated.Should().Be(utcNow);
        
        contract.ItemsToSell[0].Id.Should().NotBeEmpty();
        contract.ItemsToSell[0].Name.Should().Be("Rolex 2020 pre-owned Submariner 40mm");
        contract.ItemsToSell[0].Price.Should().Be(1667620);
        contract.ItemsToSell[0].UnitPrice.Should().Be(1667620);
        contract.ItemsToSell[0].Quantity.Should().Be(1);
        contract.ItemsToSell[0].Currency.Should().Be("czk");
        contract.ItemsToSell[0].UnitName.Should().Be("ks");
        
        contract.ItemsToSell[1].Id.Should().NotBeEmpty();
        contract.ItemsToSell[1].Name.Should().Be("Small Dior Book Tote");
        contract.ItemsToSell[1].Price.Should().Be(6400);
        contract.ItemsToSell[1].UnitPrice.Should().Be(3200);
        contract.ItemsToSell[1].Quantity.Should().Be(2);
        contract.ItemsToSell[1].Currency.Should().Be("eur");
        contract.ItemsToSell[1].UnitName.Should().Be("ks");
    }
}