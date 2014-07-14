using Nancy;

namespace ExtraDemo.Modules
{
    public class Home:NancyModule
    {
        public Home()
        {
            Get["/"] = _ => { return View["Index"]; };
        }
    }
}