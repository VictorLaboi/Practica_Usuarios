using Domain.Models;
using Kanban.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityManagment
{
    public class KanbanDbContext : DbContext
    {
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<KanbanWorkspace> Workspaces { get; set; }
        public DbSet<KanbanLayout> Layouts { get; set; }
        public DbSet<KanbanHomeworks> Homeworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<UserModel>().HasKey(u => u.Id);
            modelBuilder.Entity<KanbanWorkspace>().HasKey(w => w.Id);
            modelBuilder.Entity<KanbanLayout>().HasKey(l => l.Id);
            modelBuilder.Entity<KanbanHomeworks>().HasKey(h => h.Id);

            modelBuilder.Entity<KanbanWorkspace>()
                .HasOne<UserModel>(w => w.User)
                .WithMany()
                .HasForeignKey(w => w.UserId);

            modelBuilder.Entity<KanbanLayout>()
                .HasMany(l => l.Homeworks)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
