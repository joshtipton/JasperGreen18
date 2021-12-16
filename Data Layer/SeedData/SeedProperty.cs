using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JasperGreen18.Models
{
    internal class SeedProperty : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> entity)
        {
                entity.HasData(
             new Property
             {
                 PropertyID = 1,
                 CustomerID = 3,
                 PropertyAddress = "4433 Elm  Ave",
                 PropertyCity = "College Station",
                 PropertyState = "TX",
                 PropertyZip = "77840",
                 ServiceFee = 210.99M
             },
             new Property
             {
                 PropertyID = 2,
                 CustomerID = 1,
                 PropertyAddress = "9431 Brandon St",
                 PropertyCity = "College Station",
                 PropertyState = "TX",
                 PropertyZip = "77839",
                 ServiceFee = 99.99M
             },
             new Property
             {
                 PropertyID = 3,
                 CustomerID = 5,
                 PropertyAddress = "216 Vanessa Ln",
                 PropertyCity = "College Station",
                 PropertyState = "TX",
                 PropertyZip = "77840",
                 ServiceFee = 49.99M
             },
             new Property
             {
                 PropertyID = 4,
                 CustomerID = 2,
                 PropertyAddress = "2113 Mesquite Rd",
                 PropertyCity = "College Station",
                 PropertyState = "TX",
                 PropertyZip = "77840",
                 ServiceFee = 69.99M
             },
             new Property
             {
                 PropertyID = 5,
                 CustomerID = 4,
                 PropertyAddress = "8121 South Beach Ct",
                 PropertyCity = "College Station",
                 PropertyState = "TX",
                 PropertyZip = "77840",
                 ServiceFee = 125.00M
             },
            new Property
            {
                PropertyID = 6,
                CustomerID = 4,
                PropertyAddress = "2111 Oho Ln",
                PropertyCity = "College Station",
                PropertyState = "TX",
                PropertyZip = "77840",
                ServiceFee = 125.00M
            });
        }
    }
}