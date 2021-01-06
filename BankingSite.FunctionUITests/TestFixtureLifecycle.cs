using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSite.FunctionUITests
{
    [SetUpFixture]
    public class TestFixtureLifecycle : IDisposable
    {
        public void Dispose()
        {
            DemoHelperCode.DemoHelper.Wait(5000);

            // Cleanup and close browser
            //BrowserHost.Instance.Dispose();
        }
    }
}
