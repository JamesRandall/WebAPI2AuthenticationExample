using System.Web;
using System.Web.Mvc;

namespace WebAPI2AuthenticationExample.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
