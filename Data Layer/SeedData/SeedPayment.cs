using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JasperGreen18.Models
{
    internal class SeedPayment : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasData(
             new Payment
             {
                 PaymentID = 1,
                 CustomerID = 2,
                 PaymentDate = DateTime.Parse("2020-01-17"),
                 PaymentAmount = 200M
             },
             new Payment
             {
                 PaymentID = 2,
                 CustomerID = 1,
                 PaymentDate = DateTime.Parse("2020-05-27"),
                 PaymentAmount = 225M
             },
             new Payment
             {
                 PaymentID = 3,
                 CustomerID = 5,
                 PaymentDate = DateTime.Parse("2020-03-19"),
                 PaymentAmount = 150M
             },
             new Payment
             {
                 PaymentID = 4,
                 CustomerID = 2,
                 PaymentDate = DateTime.Parse("2020-02-22"),
                 PaymentAmount = 325M
             },
             new Payment
             {
                 PaymentID = 5,
                 CustomerID = 1,
                 PaymentDate = DateTime.Parse("2020-04-12"),
                 PaymentAmount = 170M
             },
              new Payment
              {
                  PaymentID = 6,
                  CustomerID = 3,
                  PaymentDate = DateTime.Parse("2020-05-17"),
                  PaymentAmount = 125M
              },
              new Payment
              {
                  PaymentID = 7,
                  CustomerID = 3,
                  PaymentDate = DateTime.Parse("2020-03-13"),
                  PaymentAmount = 190M
              },
              new Payment
              {
                  PaymentID = 8,
                  CustomerID = 5,
                  PaymentDate = DateTime.Parse("2020-11-06"),
                  PaymentAmount = 165M
              },
              new Payment
              {
                  PaymentID = 9,
                  CustomerID = 4,
                  PaymentDate = DateTime.Parse("2020-01-05"),
                  PaymentAmount = 225M
              },
            new Payment
            {
                PaymentID = 10,
                CustomerID = 2,
                PaymentDate = DateTime.Parse("2020-02-25"),
                PaymentAmount = 300M
            },
            new Payment
            {
                PaymentID = 11,
                CustomerID = 3,
                PaymentDate = DateTime.Parse("2020-08-26"),
                PaymentAmount = 150M
            });
        }
    }
}