using Microsoft.EntityFrameworkCore;

namespace BikeRentalAPI.Data
{
    public class BikeRentalAPIDbContext : DbContext
    {
        public BikeRentalAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
    }
}
