using Microsoft.EntityFrameworkCore;
using OnlineChat.Models;

namespace OnlineChat.Data
{
    public class Context: DbContext
    {
        //entities
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Messages).WithOne(u => u.Sender);
            //modelBuilder.Entity<User>().HasMany(g => g.Groups).WithMany(g=>g.UsersInGroup);

        }

    }
}
