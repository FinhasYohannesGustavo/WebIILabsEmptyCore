using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using WebII_Labs.CustomMiddlewares;
using WebII_Labs.Functions;

public delegate TOutput customFunc<in T, out TOutput>(T inputVar);

class Program
{
   /* static async Task WriteHeader(HttpContext context, Func<Task> next)
    {
        int num1 = 10, num2 = 20;
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("First number is: " + num1 + " Second number is: " + num2);
        Functions.customSwapper(ref num1, ref num2);
        await context.Response.WriteAsync("<br> After Swapping, First number is: " + num1 + " Second number is: " + num2);

        string fname = "Finhas";
        string lname = "Gustavo";
        await context.Response.WriteAsync("<br> First Name is " + fname + " Last Name is " + lname);
        Functions.customSwapper(ref fname, ref lname);
        await context.Response.WriteAsync("<br> After swapping names, First Name is " + fname + " Last name is " + lname);

        //using the delegate to create an anonymous square function

        //using lambda expression
        //customFunc<int, double> squareCustom = x => x * x;
        customFunc<int, double> squareCustom = Functions.SquareDouble;

        //using delegate keyword
        Func<int, int, int> sum = delegate(int x, int y)
        {
            return x + y;
        };

        int squareNum = 14;
        context.Response.WriteAsync("<br> The square of " + squareNum + " is " + squareCustom(squareNum));

        await context.Response.WriteAsync("<h2> Are you even there? </h2>");

        await next();

    }

    static async Task MiddleWare2V2(HttpContext context, Func<Task> next)
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("<h2> Some other middleware stuff for version 2</h2>");
        await next();
    }

    static async Task Middleware3(HttpContext context, Func<Task> next)
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("<h2> Using middleware 3</h2>");
        await next();
    }

    static async Task MiddleWare4(HttpContext context, RequestDelegate next)
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("<h1> Already on middleware 4</h2>");
        await next(context);
    }
   */
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        var app = builder.Build();


        /*app.MapGet("/", () => "Hello World!");

        app.Use(WriteHeader);
        app.Use(MiddleWare2V2);
        app.Use(Middleware3);
        app.Use(MiddleWare4);*/
        //This is an extension method.
        //app.UseMiddleware<ErrorHandling>();
        //app.UseMiddleware<ErrorCreator>();
        //app.UseMiddleware<UseMyDefaultFiles>("/product/Index");
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/ErrorPage.html");
        }
        //app.UseStaticFiles();


        //app.UseMiddleware<CheckStatusMiddleware>();
        //app.UseMiddleware<SetStatusMiddleware>();
        //app.UseStaticFiles();

        //MVC
        //app.MapDefaultControllerRoute("{controller=Product}/{action=getDummyProducts}/{id?}");
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Product}/{action=getDummyProducts}/{id?}"

            );


        app.Run();
    }
}