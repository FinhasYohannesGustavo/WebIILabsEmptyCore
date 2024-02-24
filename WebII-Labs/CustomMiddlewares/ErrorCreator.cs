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
            if (context.Request.Path.ToString() == "/HomePage.html")
            {
                context.Response.StatusCode = 501;
                context.Response.Headers.Add("X-Test-headerss", "Test header information");
                /*context.Response.WriteAsync("<h3> This is a test </h3>");*/

            }
            await _next(context);
        }
    }
}
