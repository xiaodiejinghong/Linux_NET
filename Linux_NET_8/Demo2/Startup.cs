using Owin;
namespace Demo2
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.Use(typeof(Base.Middleware));
        }
    }
}
