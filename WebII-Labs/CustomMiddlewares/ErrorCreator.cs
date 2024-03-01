namespace WebII_Labs.CustomMiddlewares
{
    public class ErrorCreator
    {
        private readonly RequestDelegate _next;
        public static Boolean _setStatusCodeAlready=false;
        public ErrorCreator(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            foreach(var header in context.Response.Headers)
            {
                if (header.Key =="Passed-Through" && !_setStatusCodeAlready)
                {
                    if (header.Value == "YES")
                    {
                        _setStatusCodeAlready=true;
                        await _next(context);

                    }
                }
            }
            if (context.Request.Path.ToString() == "/" && !_setStatusCodeAlready)
            {
                context.Response.StatusCode = 404;
                context.Response.Headers.Add("X-Test-headerss", "Test header information");
                //return;
            }
            
        }
    }
}
