namespace Demo1
{
    using Owin;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/realtime", new Microsoft.AspNet.SignalR.HubConfiguration() { });
            app.UseStaticFiles("/Page");
            app.UseStaticFiles("/Scripts");
        }
    }
}