using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MvcBurger.Persistance.Contexts;

namespace MvcBurger.Web.ContextFactory
{
    public class BurgerDbContextFactory : IDesignTimeDbContextFactory<BurgerDbContext>
    {
        public BurgerDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BurgerDbContext>()
                .UseSqlServer(configuration.GetConnectionString("SqlServerConn"),
                prj => prj.MigrationsAssembly("MvcBurger.Web"));

            return new BurgerDbContext(builder.Options);

        }
    }
}

