namespace WebII_Labs.CustomMiddlewares
{
    public class ErrorHandling
    {
        private readonly RequestDelegate _next;
        public ErrorHandling(RequestDelegate next) { 
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/HomePage.html")
            {
                await _next(context);
                //context.Response.ContentType = "text/html";
                if (context.Response.StatusCode == 501)
                {
                    String Path = "/ErrorPage.html";
                    context.Request.Path= Path;
                    context.Response.Redirect(Path);
                    context.Response.WriteAsync("<h2> This is error 501</h2>");

                    context.Response.Headers.Add("X-Whathappened", "The server can not be found!!!");
                    return;
                }
                else if (context.Response.StatusCode == 404)
                {
                    //context.Response.WriteAsync("<h2> Are you even listening?</h2>");
                    context.Response.Headers.Add("X-Whathappened", "Page Not found!!!");
                    return;
                }
                else
                {
                    //context.Response.WriteAsync("<h2> This is error 403?</h2>");
                    context.Response.Headers.Add("X-test", "NOTHING HAPPENED!");
                    return;
                }

            }
        }
    }
}
