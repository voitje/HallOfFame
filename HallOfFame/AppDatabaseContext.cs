using HallOfFame.Model;
using Microsoft.EntityFrameworkCore;

namespace HallOfFame
{
    public class AppDatabaseContext : DbContext
    {
        #region Properties

        public DbSet<Person> Persons { get; set; }

        public DbSet<Skill> Skills { get; set; }

        #endregion

        #region Constructor

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(
            options)
        {
        }

        #endregion
    }
}