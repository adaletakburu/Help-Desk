using HelpDesk.Api.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository userRepository;

        public ConfirmEmailCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetAsync(i => i.Id == request.ConfirmationId);

            if (user is null)
                throw new Exception("User not found.");
            if (user.EmailConfirmed)
                throw new Exception("Email address is already confirmed!");

            user.EmailConfirmed = true;
            await userRepository.UpdateAsync(user);
            return true;
        }
    }
}
