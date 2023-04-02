using System.Collections.Generic;

namespace HelpDesk.Api.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public Role Role { get; set; }


        public virtual ICollection<Demand> Demands { get; set; }
        public virtual ICollection<DemandMessage> DemandMessages { get; set; }
    }
    public enum Role
    {
        User, Administrator
    }
}
