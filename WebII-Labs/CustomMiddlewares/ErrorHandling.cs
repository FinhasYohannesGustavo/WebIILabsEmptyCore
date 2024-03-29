﻿using WebII_Labs.CustomMiddlewares;

public class ErrorHandling
{
    private readonly RequestDelegate _next;
    public ErrorHandling(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        ErrorCreator._setStatusCodeAlready=false;
        await _next(context);

        if (context.Request.Path == "/")
        {
            if (context.Response.StatusCode == 501)
            {
                context.Response.Headers.Add("X-Whathappened", "The server can not be found!!!");
                context.Response.Redirect("/ServerError.html",false);
                context.Response.Headers.Add("Passed-Through", "YES");
                await _next(context);
            }
            else if (context.Response.StatusCode == 404)
            {
                context.Response.Headers.Add("X-Whathappened", "Page Not found!!!");
                context.Response.Redirect("/ErrorPage.html",false);
                context.Response.Headers.Add("Passed-Through", "YES");
                await _next(context);
            }
            else
            {
                context.Response.Headers.Add("X-test", "NOTHING HAPPENED!");
                context.Response.ContentType = "text/html";
                context.Response.WriteAsync("<h1>This is the default way we handle all other codes!</h1>");
                context.Response.Headers.Add("Passed-Through", "YES");
                await _next(context);
            }
            //return;
        }
    }
}