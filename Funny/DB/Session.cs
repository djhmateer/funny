using Funny.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funny.DB {
    public class Session : DbContext {
        public Session()
            : base(nameOrConnectionString: "Funny") {
            // Nice for development
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Session>());
        }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
