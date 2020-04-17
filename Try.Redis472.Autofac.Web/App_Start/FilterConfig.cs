using System.Web;
using System.Web.Mvc;

namespace Try.Redis472.Autofac.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}