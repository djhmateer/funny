using System.Data.Entity;
using Core.Models;

namespace Core.DB {
    public class Session : DbContext {
        public Session()
            : base(nameOrConnectionString: "Funny") {
            // Nice for development - problem with EF6 and migrations?
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Session>());
        }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
