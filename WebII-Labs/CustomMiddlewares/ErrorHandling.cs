public class ErrorHandling
{
    private readonly RequestDelegate _next;
    public ErrorHandling(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Request.Path != "/HomePage.html")
        {
            if (context.Response.StatusCode == 501)
            {
                context.Response.Headers.Add("X-Whathappened", "The server can not be found!!!");
                context.Response.Redirect("/ServerError.html");
                return;
            }
            else if (context.Response.StatusCode == 404)
            {
                context.Response.Headers.Add("X-Whathappened", "Page Not found!!!");
                context.Response.Redirect("/ErrorPage.html");
                return;
            }
            else
            {
                context.Response.Headers.Add("X-test", "NOTHING HAPPENED!");
                context.Response.ContentType = "text/html";
                context.Response.WriteAsync("<h1>This is the default way we handle all other codes!</h1>");
                return;
            }
            return;
        }
    }
}