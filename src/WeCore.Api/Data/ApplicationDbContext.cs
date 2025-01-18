using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeCore.Api.Models;

namespace WeCore.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<CardLabel> CardLabels { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<IwaConfiguration> IwaConfigurations { get; set; }
        public DbSet<BoardList> Lists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BoardList>()
                .HasIndex(l => new { l.BoardId, l.Order })
                .IsUnique();

            builder.Entity<Card>()
                .HasIndex(c => new { c.ListId, c.Order })
                .IsUnique();
        }
    }
}
