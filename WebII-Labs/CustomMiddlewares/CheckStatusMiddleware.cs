namespace WebII_Labs.CustomMiddlewares
{
    public class CheckStatusMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckStatusMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 404)
            {
                context.Response.Redirect("/ErrorPage.html");
               // await context.Response.SendFileAsync("/ErrorPage.html");
                return;
            }
        }
    }
}
