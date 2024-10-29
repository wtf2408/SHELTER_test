using Microsoft.EntityFrameworkCore;

namespace SHELTER_test_task_api
{
    public class ShelterContext : DbContext
    {
        public ShelterContext() {}
        public ShelterContext(DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
    }
}
