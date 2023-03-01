using Microsoft.EntityFrameworkCore;

namespace Restaurant.Models
{
    public class RestaurantDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion("8.0.32");
            optionsBuilder.UseMySql("server=localhost;user=root;password=Niranji@1997;database=Restaurant", serverVersion);
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)

            //#pragma warning restore CS0311
            : base(options)
        { }

        public DbSet<User> users { get; set; }
        public DbSet<O_Restaurant> restaurants { get; set; }
        public DbSet<Fooditem> fooditems { get; set; }
        public DbSet<UserOrder> userorders { get; set; }
        public DbSet<Cheffcs> cheffcs { get; set; }


    }
}