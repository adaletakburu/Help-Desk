namespace HelpDesk.Api.WebApi.Middleware
{
    public static class ExceptionRegistration
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
