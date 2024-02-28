namespace WebII_Labs.CustomMiddlewares
{
    public class ErrorCreator
    {
        private readonly RequestDelegate _next;
        public ErrorCreator(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.ToString() == "/")
            {
                context.Response.StatusCode = 404;
                context.Response.Headers.Add("X-Test-headerss", "Test header information");
                return;
            }
            await _next(context);
        }
    }
}
