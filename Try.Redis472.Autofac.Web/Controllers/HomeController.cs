using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Try.Redis472.Autofac.Web.Controllers
{
    using Services;

    public class HomeController : Controller
    {
        private readonly ITestService service;

        public HomeController(ITestService service)
        {
            this.service = service;
        }
        
        public ActionResult Index()
        {
            // Act
            var result = service.Get();
            if (string.IsNullOrWhiteSpace(result))
            {
                service.Set("Hello World");
                result = service.Get();
            }
            
            return Content(result);
        }
    }
}