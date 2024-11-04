using System.Web;
using System.Web.Mvc;

namespace K22CNT2_VuAnhDuong_2210900017
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
