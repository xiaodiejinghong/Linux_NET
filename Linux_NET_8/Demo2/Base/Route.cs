using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Demo2.Base
{
    public class Route
    {
        private static Dictionary<string, Tuple<string, Type, Dictionary<string, MethodInfo>>> routeTable = new Dictionary<string, Tuple<string, Type, Dictionary<string, MethodInfo>>>();

        public static void RegisterRoute()
        {
            routeTable.Clear();
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (!type.Name.Equals("Controller") && type.Name.EndsWith("Controller"))
                {
                    var t = assembly.GetType(type.FullName);
                    Dictionary<string, MethodInfo> infoDic = new Dictionary<string, MethodInfo>();
                    foreach (var methods in type.GetMethods())
                    {
                        infoDic.Add(methods.Name, t.GetMethod(methods.Name));
                    }
                    routeTable.Add(type.Name, new Tuple<string, Type, Dictionary<string, MethodInfo>>(type.FullName, type, infoDic));
                }
            }
        }

        public static dynamic Handle(string path)
        {
            var args = path.Split('/');
            var controllerName = (args.Count() > 1) ? args[1] + "Controller" : "HomeController";
            var actionName = (args.Count() > 2) ? args[2] : "Index";
            if (!CheckExists(controllerName, actionName))
            {
                return Get404Page();
            }
            var instance = Activator.CreateInstance(routeTable[controllerName].Item2, new object[] { path });
            return routeTable[controllerName].Item3[actionName].Invoke(instance, new object[] { });
        }

        private static bool CheckExists(string controllerName, string actionName)
        {
            if (!routeTable.ContainsKey(controllerName))
            {
                return false;
            }
            if (!routeTable[controllerName].Item3.ContainsKey(actionName))
            {
                return false;
            }
            return true;
        }

        private static dynamic Get404Page()
        {
            var viewsPath = Directory.GetCurrentDirectory();
            viewsPath = (viewsPath.EndsWith("\\") || viewsPath.EndsWith("/")) ? viewsPath + "Views/" : (viewsPath + "/Views/");
            string body = File.ReadAllText(viewsPath + "404.html");
            return Encoding.UTF8.GetBytes(body);
        }

    }
}