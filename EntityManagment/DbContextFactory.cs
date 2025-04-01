using EntityManagment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagment
{
    public class DbContextFactory: DbContext
    {
       private readonly Action<DbContextOptionsBuilder> _configureOptionBuilder; 
        public DbContextFactory(Action<DbContextOptionsBuilder> configureOptionBuilder)
        {
            _configureOptionBuilder = configureOptionBuilder;
        }

        public KanbanDbContext createDbContext()
        {
            DbContextOptionsBuilder<KanbanDbContext> dbContextOptions = new DbContextOptionsBuilder<KanbanDbContext>();
            _configureOptionBuilder(dbContextOptions);
            return new KanbanDbContext(dbContextOptions.Options);

        }
    }
}
