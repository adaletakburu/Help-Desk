using System;

namespace HelpDesk.Common.Events.User
{
    public class UserEmailConfirmedEvent
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
    }
}
