using AutoMapper;
using HelpDesk.Api.Application.Interfaces.Repositories;
using HelpDesk.Common;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace HelpDesk.Api.Application.Features.Commands.User.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetAsync(i => i.UserName == request.UserName && i.Password == PasswordEncryptor.Encryptor(request.Password));

            if (dbUser is null)
                throw new Exception("User not found.");
            if (dbUser.EmailConfirmed is not true)
                throw new Exception("Verify your email.");


            var user = mapper.Map<LoginCommandResponse>(dbUser);


            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
                new Claim(ClaimTypes.Name, dbUser.UserName),
                new Claim(ClaimTypes.GivenName, dbUser.FirstName),
                new Claim(ClaimTypes.Surname, dbUser.LastName),
                new Claim(ClaimTypes.Email, dbUser.EmailAddress),
                new Claim(ClaimTypes.Role, dbUser.Role.ToString()),
            };

            user.Token = GenerateToken.Generate(configuration, claims);

            return user;
        }
    }
}
