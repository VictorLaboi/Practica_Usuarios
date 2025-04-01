using Microsoft.EntityFrameworkCore;

namespace EFCoreManagment
{
    public class KanbanDbContext : DbContext
    {
        public DbSet<UserModel> users { get; set; }
        public DbSet<UserModel> users { get; set; }
        public DbSet<UserModel> users { get; set; }

        
    }
}
