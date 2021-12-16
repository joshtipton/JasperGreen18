using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JasperGreen18.Models
{
    internal class SeedCustomer : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(
             new Customer
             {
                 CustomerID = 1,
                 CustomerFirstName = "Susan",
                 CustomerLastName = "Anthony",
                 BillingAddress = "6432 Elm Crest Ct",
                 BillingCity = "College Station",
                 BillingState = "TX",
                 BillingZip = "77840",
                 CustomerPhone = "8173083025",
             },
             new Customer
             {
                 CustomerID = 2,
                 CustomerFirstName = "Sarah",
                 CustomerLastName = "Timmins",
                 BillingAddress = "2099 Alibi Rd",
                 BillingCity = "Bryan",
                 BillingState = "TX",
                 BillingZip = "77842",
                 CustomerPhone = "9991029412",
             },
             new Customer
             {
                 CustomerID = 3,
                 CustomerFirstName = "Mike",
                 CustomerLastName = "Scott",
                 BillingAddress = "87 Cool Plaza Rd",
                 BillingCity = "College Station",
                 BillingState = "TX",
                 BillingZip = "77844",
                 CustomerPhone = "7281048294",
             },
             new Customer
             {
                 CustomerID = 4,
                 CustomerFirstName = "Larry",
                 CustomerLastName = "Bird",
                 BillingAddress = "8243 Celtics Ave",
                 BillingCity = "Bryan",
                 BillingState = "TX",
                 BillingZip = "77816",
                 CustomerPhone = "5927731088",
             },
             new Customer
             {
                 CustomerID = 5,
                 CustomerFirstName = "Tim",
                 CustomerLastName = "Morgan",
                 BillingAddress = "6172 Texas Ave S",
                 BillingCity = "College Station",
                 BillingState = "TX",
                 BillingZip = "77840",
                 CustomerPhone = "8229136239",
             });
        }
    }
}