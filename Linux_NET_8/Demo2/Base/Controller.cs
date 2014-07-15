using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Demo2.Base
{
    public class Controller
    {
        protected string controllerName;

        protected string actionName;

        protected Controller(string path)
        {
            var args = path.Split('/');
            this.controllerName = args.Count() > 1 ? args[1] : "Home";
            this.actionName = args.Count() > 2 ? args[2] : "Index";
        }

        protected dynamic View()
        {
            return this.View(this.actionName);
        }

        protected dynamic View(string viewName)
        {
            var path = this.GetPath("Views/" + this.controllerName) + viewName + ".html";
            var body = "<html xmlns='http://www.w3.org/1999/xhtml'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head><body>找不到HTML视图</body></html>";
            if (File.Exists(path))
            {
                body = File.ReadAllText(path);
            }
            return Encoding.UTF8.GetBytes(body);
        }

        protected string GetPath(string path)
        {
            var fullPath = Path.GetFullPath(path);
            return (fullPath.EndsWith("/") || fullPath.EndsWith("\\")) ? fullPath : (fullPath + "/");
        }

    }
}