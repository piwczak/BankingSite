using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Configuration;

namespace BankingSite.FunctionUITests
{
    public static class BrowserHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl;

        static BrowserHost()
        {
            Instance.Run("BankingSite", 4223, config => config.WithRouteConfig(RouteConfig.RegisterRoutes));

            RootUrl = Instance.Application.Browser.Url;
        }
    }
}
