using Microsoft.EntityFrameworkCore;

namespace ComicsBurger.Persistance.Contexts
{
    public class BurgerDbContext :DbContext
    {
        public BurgerDbContext(DbContextOptions<BurgerDbContext> options) : base(options)
        {

        }

        //




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BurgerDbContext).Assembly);
        }
    }
}
