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
        public DbSet<BoardUser> BoardUsers { get; set; }

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

            modelBuilder.Entity<BoardUser>()
                .HasKey(bu => new { bu.BoardId, bu.UserId });

            modelBuilder.Entity<BoardUser>()
                .HasOne(bu => bu.Board)
                .WithMany(b => b.BoardUsers)
                .HasForeignKey(bu => bu.BoardId);

            modelBuilder.Entity<BoardUser>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.BoardUsers)
                .HasForeignKey(bu => bu.UserId);
        }
    }
}
