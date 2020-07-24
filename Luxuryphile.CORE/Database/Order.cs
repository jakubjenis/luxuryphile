﻿namespace Luxuryphile.CORE.Database
{
    public class Order
    {
        public int Id { get; set; }

        public OrderState State { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipCode { get; set; }
        
        public string AddressCountry { get; set; }

        public string AddressOneLine =>
            AddressCity != null || AddressStreet != null || AddressZipCode != null 
                ? $"{AddressStreet}, {AddressCity}, {AddressZipCode}"
                : string.Empty;

        public int InvoiceId { get; set; }
    }

    public enum OrderState
    {
        Created,
        Sent,
        Paid,
        Shipped
    }
}