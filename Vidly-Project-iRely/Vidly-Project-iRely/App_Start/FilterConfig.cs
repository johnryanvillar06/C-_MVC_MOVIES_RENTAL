using System.Web;
using System.Web.Mvc;

namespace Vidly_Project_iRely
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
