using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JasperGreen18.Models
{
    internal class CrewConfig : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> entity)
        {

            // composite primary key
            entity.HasKey(c => c.CrewID);

            // one-to-many relationship between Crew and Employees
            entity.HasOne(c => c.CrewForeman)
                .WithMany(e => e.CrewsF)
                .HasForeignKey(c => c.CrewForemanID);

            entity.HasOne(c => c.CrewMember1)
               .WithMany(e => e.Crews1)
               .HasForeignKey(c => c.CrewMember1ID);

            entity.HasOne(c => c.CrewMember2)
               .WithMany(e => e.Crews2)
               .HasForeignKey(c => c.CrewMember2ID);
        }
    }
}
