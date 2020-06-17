using Inspirator.Model.Context;
using Inspirator.Repository;
using Inspirator.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Inspirator.UnitTest1
{
    [TestClass]
    public class RepositoryTest
    {
        public const string constr = "Server=.;Database=InspiratorDB;User Id=sa;Password=sa;";
        public static DbContextOptions<MainContext> CreateDbContextOptions(string databaseName)
        {
            var serviceProvider = new ServiceCollection().
                AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MainContext>();
            builder.UseSqlServer(databaseName)
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestMethod]
        public async Task StudentRepositoryTest()
        {
            //var context = new MainContext(CreateDbContextOptions(constr));
            //var u = new UserService(new UserRepository(context));
            //int t = await u.Insert();
            //Assert.AreEqual(t, 1);
        }
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(string.Empty, string.Empty);
        }
    }
}
