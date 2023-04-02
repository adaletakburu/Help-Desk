using UserService;
using UserService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        services.AddHostedService<Worker>();

        services.AddTransient<UserService.Services.UserService>();
        services.AddTransient<EmailService>();


    })
    .Build();

await host.RunAsync();
