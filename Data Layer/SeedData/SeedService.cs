using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JasperGreen18.Models
{
    internal class SeedService : IEntityTypeConfiguration<ProvideService>
    {
        public void Configure(EntityTypeBuilder<ProvideService> entity)
        {

            entity.HasKey(s => s.ServiceID);

            entity.HasData(
               new ProvideService
               {
                   ServiceDate = DateTime.Parse("2020-05-11"),
                   ServiceFee = 80M,
                   ServiceID = 1,
                   CustomerID = 1,
                   PropertyID = 1,
                   PaymentID = 1,
                   CrewID = 1
               },
               new ProvideService
               {
                   ServiceDate = DateTime.Parse("2020-03-06"),
                   ServiceFee = 60M,
                   ServiceID = 2,
                   CustomerID = 2,
                   PropertyID = 2,
                   PaymentID = 2,
                   CrewID = 3
               },
                new ProvideService
                {
                    ServiceDate = DateTime.Parse("2020-07-19"),
                    ServiceFee = 120M,
                    ServiceID = 3,
                    CustomerID = 1,
                    PropertyID = 3,
                    PaymentID = 3,
                    CrewID = 4
                },
                new ProvideService
                {
                    ServiceDate = DateTime.Parse("2020-01-22"),
                    ServiceFee = 100M,
                    ServiceID = 4,
                    CustomerID = 1,
                    PropertyID = 5,
                    PaymentID = 4,
                    CrewID = 1
                },
                new ProvideService
                {
                    ServiceDate = DateTime.Parse("2020-09-07"),
                    ServiceFee = 200M,
                    ServiceID = 5,
                    CustomerID = 4,
                    PropertyID = 2,
                    PaymentID = 5,
                    CrewID = 3
                },
               new ProvideService
               {
                   ServiceDate = DateTime.Parse("2020-05-20"),
                   ServiceFee = 250M,
                   ServiceID = 6,
                   CustomerID = 3,
                   PropertyID = 3,
                   PaymentID = 6,
                   CrewID = 3
               },
                new ProvideService
                {
                    ServiceDate = DateTime.Parse("2020-02-11"),
                    ServiceFee = 29.99M,
                    ServiceID = 7,
                    CustomerID = 5,
                    PropertyID = 2,
                    PaymentID = 7,
                    CrewID = 3
                },
                new ProvideService
                {
                    ServiceDate = DateTime.Parse("2020-06-13"),
                    ServiceFee = 225M,
                    ServiceID = 8,
                    CustomerID = 5,
                    PropertyID = 2,
                    PaymentID = 8,
                    CrewID = 1
                },
                new ProvideService
                {
                    ServiceDate = DateTime.Parse("2020-08-24"),
                    ServiceFee = 325M,
                    ServiceID = 9,
                    CustomerID = 2,
                    PropertyID = 2,
                    PaymentID = 9,
                    CrewID = 1
                },
                new ProvideService
                {
                    ServiceDate = DateTime.Parse("2020-09-03"),
                    ServiceFee = 175M,
                    ServiceID = 10,
                    CustomerID = 4,
                    PropertyID = 4,
                    PaymentID = 10,
                    CrewID = 4
                });
        }
    }
}
        
