namespace Demo1
{
    using Owin;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(MyMiddleware));
            
        }
    }
}
