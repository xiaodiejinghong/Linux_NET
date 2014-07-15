using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo2.Controller
{
    public class HomeController : Base.Controller
    {
        public HomeController(string path) : base(path) { }

        public dynamic Index()
        {
            return View();
        }

        

    }
}