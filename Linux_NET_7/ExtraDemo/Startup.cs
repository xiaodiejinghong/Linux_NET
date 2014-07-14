using Owin;
using Nancy.Owin;

namespace ExtraDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}