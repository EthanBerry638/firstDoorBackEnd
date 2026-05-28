namespace firstDoorBackEnd.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (CareerJetForbiddenException ex)
            {
                HandleCareerJetForbiddenException(context, ex);
            }
        }

        private async Task HandleCareerJetForbiddenException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            await context.Response.WriteAsJsonAsync(new { ex.Message });
        }
    }
}
