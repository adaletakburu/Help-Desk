using HelpDesk.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Common.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddCommonRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            return services;
        }
    }
}
