using System.Web.Http;

namespace CustomerService.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            DependencyResolver.Initialize(GlobalConfiguration.Configuration);
        }
    }
}