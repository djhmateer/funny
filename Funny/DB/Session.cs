using Core.Models;
using System.Data.Entity;

namespace Core.DB {
    public class Session : DbContext {
        public Session() : base(nameOrConnectionString: "Funny") {
            // Nice for development
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Session>());
        }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
