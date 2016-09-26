using System.Web.Mvc;
using ProjetoDDD.Infra.CrossCutting.MvcFilters;

namespace ProjetoDDD.UI.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
