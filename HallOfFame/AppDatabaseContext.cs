using HallOfFame.Model;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base (options)
        {

        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Skill> Skills { get; set; }
    }
}