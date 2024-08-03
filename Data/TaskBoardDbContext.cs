using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Models;

namespace TaskBoard.Data
{
    public class TaskBoardDbContext : IdentityDbContext<User>
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<CardLabel> CardLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CardLabel>()
                .HasKey(cl => new { cl.CardId, cl.LabelId });

            modelBuilder.Entity<CardLabel>()
                .HasOne(cl => cl.Card)
                .WithMany(c => c.CardLabels)
                .HasForeignKey(cl => cl.CardId);

            modelBuilder.Entity<CardLabel>()
                .HasOne(cl => cl.Label)
                .WithMany(l => l.CardLabels)
                .HasForeignKey(cl => cl.LabelId);

            // Настройка отношения между User и Board
            modelBuilder.Entity<Board>()
                .HasOne(b => b.User)
                .WithMany(u => u.Boards)
                .HasForeignKey(b => b.UserId);
        }
    }
}
