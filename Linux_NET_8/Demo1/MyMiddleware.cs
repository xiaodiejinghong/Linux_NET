using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
namespace Demo1
{
    using AppFun = Func<IDictionary<string, object>, Task>;
    public class MyMiddleware
    {
        private readonly AppFun _env;

        public MyMiddleware(AppFun env)
        {
            if (env == null) throw new ArgumentNullException("OWIN环境参数为空");
            this._env = env;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            var responseBody = "Linux.NET 学习手记（8）&nbsp;        --小蝶惊鸿";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
            ((IDictionary<string, string[]>)env["owin.ResponseHeaders"]).Add("Content-Type", new string[] { "text/html; charset=utf-8" });
            ((Stream)env["owin.ResponseBody"]).Write(responseBodyBytes, 0, responseBodyBytes.Length);
            return this._env(env);
        }
    }
}