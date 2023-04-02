using System;
using System.Collections.Generic;

namespace HelpDesk.Api.Domain.Models
{
    public class Demand : BaseEntity
    {
        public Guid UserId { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<DemandMessage> DemandMessages { get; set; }

    }

    public enum Status
    {
        Active, Passive, Solved, Unsolved
    }
}
