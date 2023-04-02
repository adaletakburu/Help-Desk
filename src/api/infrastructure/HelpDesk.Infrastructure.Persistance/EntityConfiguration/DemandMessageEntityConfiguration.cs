using HelpDesk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpDesk.Infrastructure.Persistance.EntityConfiguration
{
    public class DemandMessageEntityConfiguration : BaseEntityConfiguration<DemandMessage>
    {
        public override void Configure(EntityTypeBuilder<DemandMessage> builder)
        {
            base.Configure(builder);
            builder.ToTable("DemandMessage");

            builder.HasOne(i => i.User).WithMany(i => i.DemandMessages).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Demand).WithMany(i => i.DemandMessages).HasForeignKey(i => i.DemandId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
