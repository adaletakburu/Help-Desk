using System;

namespace HelpDesk.Api.Domain.Models
{
    public class DemandMessage : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid DemandId { get; set; }
        public string Message { get; set; }

        public virtual User User { get; set; }
        public virtual Demand Demand { get; set; }
    }
}
