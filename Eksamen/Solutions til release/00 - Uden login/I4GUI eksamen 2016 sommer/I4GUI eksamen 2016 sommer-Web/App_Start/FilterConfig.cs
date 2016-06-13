using System.Web;
using System.Web.Mvc;

namespace I4GUI_eksamen_2016_sommer_Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
