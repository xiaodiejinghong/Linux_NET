using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Reflection;

namespace Demo2.Base
{
    using AppFun = Func<IDictionary<string, object>, Task>;
    using System.IO;
    public class Middleware
    {
        private readonly AppFun _env;       

        public Middleware(AppFun env)
        {
            if (env == null) throw new ArgumentNullException("OWIN 环境变量为空");
            Base.Route.RegisterRoute();
            _env = env;
        }

        public Task Invoke(IDictionary<string, object> env)
        {

            var path = env["owin.RequestPath"].ToString();

            var body= (byte[])Base.Route.Handle(path);

            ((Stream)env["owin.ResponseBody"]).Write(body, 0, body.Length);

            return _env(env);
        }

    }
}