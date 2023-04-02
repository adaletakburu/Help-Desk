using HelpDesk.Common;
using HelpDesk.Common.Events.User;
using UserService.Services;

namespace UserService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly EmailService emailService;
        private readonly Services.UserService userService;
        public Worker(ILogger<Worker> logger, IConfiguration configuration, EmailService emailService, Services.UserService userService)
        {
            this.logger = logger;
            this.emailService = emailService;
            this.userService = userService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(RabbitMqConstants.UserExchangeName)
                .EnsureQueue(RabbitMqConstants.UserEmailConfirmedQueueName, RabbitMqConstants.UserExchangeName)
                .Receive<UserEmailConfirmedEvent>(emailConfirmed =>
                {
                    var id = userService.EmailById(emailConfirmed).GetAwaiter().GetResult();
                    var link = emailService.GenerateConfirmationLink(id);
                    emailService.SendEmail(emailConfirmed.Id.ToString(), link).GetAwaiter().GetResult(); ;
                })
                .StartConsuming(RabbitMqConstants.UserEmailConfirmedQueueName);
        }
    }
}