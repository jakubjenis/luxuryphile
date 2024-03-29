﻿using System.ComponentModel.DataAnnotations;

namespace Luxuryphile.Web.Data.CreateContract
{
    public class CreateContractModel
    {
        public decimal Provision { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string DocumentNumber { get; set; }

        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public List<CreateContractItemModel> Items { get; set; } = new();

    }
}
