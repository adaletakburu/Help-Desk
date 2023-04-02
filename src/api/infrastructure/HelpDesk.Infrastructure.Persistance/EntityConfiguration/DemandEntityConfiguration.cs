using HelpDesk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Persistance.EntityConfiguration
{
    public class DemandEntityConfiguration : BaseEntityConfiguration<Demand>
    {
        public override void Configure(EntityTypeBuilder<Demand> builder)
        {
            base.Configure(builder);

            builder.ToTable("Demand");
            builder.HasOne(i => i.User).WithMany(i => i.Demands).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
