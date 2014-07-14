namespace Demo2
{
    using Owin;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/realtime/trackingConn", map => { map.RunSignalR<MyConn.TrackingConn>(); });
            app.UseStaticFiles("/Page");
            app.UseStaticFiles("/Scripts");
        }
    }
}