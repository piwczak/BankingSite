using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSite.IntegrationTests
{
    [SetUpFixture]
    public class TestFixtureLifecycle
    {
        public TestFixtureLifecycle()
        {
            EnsureDataDirectoryConnectionStringPlaceholderIsSet();

            EnsureNoExistingDatabaseFiles();
        }

        private void EnsureNoExistingDatabaseFiles()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", TestContext.CurrentContext.TestDirectory);
        }

        private void EnsureDataDirectoryConnectionStringPlaceholderIsSet()
        {
            const string connectionString = "name=DefaultConnection";

            if (Database.Exists(connectionString))
            {
                Database.Delete(connectionString);
            }
        }
    }
}
