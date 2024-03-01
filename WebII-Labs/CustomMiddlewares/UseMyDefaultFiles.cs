namespace WebII_Labs.CustomMiddlewares
{
    public class UseMyDefaultFiles
    {
        private readonly RequestDelegate _next;
        private readonly String _path;
        public UseMyDefaultFiles(RequestDelegate next) {
            _next = next;
        }
        public UseMyDefaultFiles(RequestDelegate next,String path)
        {
            _next = next;
            _path = path;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/")
            {
                if(_path == null) {
                    context.Response.Redirect("HomePage.html", false);
                    
                }
                else
                {
                    context.Response.Redirect(_path,false);
                    
                }

            }
            await _next(context);
        }
    }
}
