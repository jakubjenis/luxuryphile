﻿using Luxuryphile.Api.Contract;

namespace Luxuryphile.Web.Data;

public static class FakeData
{
    public static ContractRow CreateFakeContract(int number)
    {
        return new ContractRow(
            Id: Guid.NewGuid(),
            DateCreated: DateTime.UtcNow,
            Seller: "Jakub Jenis",
            Number: number,
            Provision: 15);
    }

    public static ContractDetail CreateFakeContractDetail(int number)
    {
        return new ContractDetail(
                Guid.NewGuid(),
                number,
                DateTime.Now,
                0.2M,
                new ClientDetail(
                    Guid.NewGuid(),
                    "Jakub",
                    "Jenis",
                    "jakubjenis@gmail.com",
                    "92134984234",
                    "Hugo Haase 2",
                    DateOnly.FromDateTime(DateTime.Now.AddYears(-30)),
                    "SJ234778",
                    null),
                new SoldItem[]
                {
                    new SoldItem("Rolex Explorer", 120000, "CZK", "Bez vady")
                }
            );
    }
}