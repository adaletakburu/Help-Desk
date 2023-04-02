using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Common;
using HelpDesk.Common.Events.User;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.User.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public RegisterCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        async Task<Guid> IRequestHandler<RegisterCommand, Guid>.Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetAsync(i => i.EmailAddress == request.EmailAddress || i.UserName == request.UserName);

            if (dbUser is not null)
                throw new Exception("User already exists");

            var user = mapper.Map<Domain.Models.User>(request);
            user.Password = PasswordEncryptor.Encryptor(request.Password);

            await userRepository.AddAsync(user);

            var @event = new UserEmailConfirmedEvent()
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress
            };

            QueueFactory.SendMessageToExchange(exchangeName: RabbitMqConstants.UserExchangeName,
                                                exchangeType: RabbitMqConstants.DefaultExchangeType,
                                                queueName: RabbitMqConstants.UserEmailConfirmedQueueName,
                                                obj: @event);

            return user.Id;
        }
    }
}
