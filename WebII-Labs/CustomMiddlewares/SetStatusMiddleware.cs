namespace WebII_Labs.CustomMiddlewares
{
    public class SetStatusMiddleware
    {
        private readonly RequestDelegate _next;
        public SetStatusMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode=404;
            await _next(context);
        }
    }
}