using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JasperGreen18.Models
{
    internal class SeedCrew : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> entity)
        {
            entity.HasData(
            new Crew
            {
                CrewID = 1,
                CrewForemanID = 1,
                CrewMember1ID = 2,
                CrewMember2ID = 3
            },
            new Crew
            {
                CrewID = 2,
                CrewForemanID = 4,
                CrewMember1ID = 5,
                CrewMember2ID = 6
            },
            new Crew
            {
                CrewID = 3,
                CrewForemanID = 7,
                CrewMember1ID = 8,
                CrewMember2ID = 9
            },
            new Crew
            {
                CrewID = 4,
                CrewForemanID = 10,
                CrewMember1ID = 11,
                CrewMember2ID = 12
            },
            new Crew
            {
                CrewID = 5,
                CrewForemanID = 13,
                CrewMember1ID = 14,
                CrewMember2ID = 15
            });
        }
    }
}