using FluentValidation;
using FluentValidation.AspNetCore;
using HelpDesk.Api.Application.Features.Commands.Demand.Create;
using HelpDesk.Api.Application.Features.Commands.Demand.Update;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Create;
using HelpDesk.Api.Application.Features.Commands.DemandMessage.Update;
using HelpDesk.Api.Application.Features.Commands.User.Register;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HelpDesk.Api.Application.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var asm = Assembly.GetExecutingAssembly();

            services.AddMediatR(asm);
            services.AddAutoMapper(asm);

            services.AddFluentValidationAutoValidation();
            //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddScoped<IValidator<CreateDemandCommand>, CreateDemandCommandValidator>();
            services.AddScoped<IValidator<UpdateDemandCommand>, UpdateDemandCommandValidator>();

            services.AddScoped<IValidator<CreateDemandMessageCommand>, CreateDemandMessageCommandValidator>();
            services.AddScoped<IValidator<UpdateDemandMessageCommand>, UpdateDemandMessageCommandValidator>();



            return services;
        }
    }
}
