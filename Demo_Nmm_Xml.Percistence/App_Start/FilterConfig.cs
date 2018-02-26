using System.Web;
using System.Web.Mvc;

namespace Demo_Nmm_Xml
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
