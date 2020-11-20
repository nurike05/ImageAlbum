using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ImageGallery
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public interface IAuthenticationFilter
        {
            void OnAuthentication(AuthenticationContext filterContext);
            void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext);
        }
    }
}
