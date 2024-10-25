using System.Web;
using System.Web.Mvc;

namespace Net1711_231_ASM4_SE172092_NGUYENHOANGSON.MVCWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
