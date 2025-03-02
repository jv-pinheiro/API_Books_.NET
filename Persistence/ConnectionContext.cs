using Microsoft.EntityFrameworkCore;
using API_Books.Model;

namespace API_Books.Persistence
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");
                entity.HasKey(b => b.id);

                entity.Property(b => b.nome)
                    .HasColumnName("nome");
                //.IsRequired();

                entity.Property(b => b.autor)
                    .HasColumnName("autor");
                //.IsRequired();

                entity.Property(b => b.status)
                    .HasColumnName("status");
                    //.IsRequired();
            });
        }
    }
}
