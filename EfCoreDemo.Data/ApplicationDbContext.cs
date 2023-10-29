using EfCoreDemo.Data.EntityConfigurations;
using EfCoreDemo.Model;
using EfCoreDemo.Model.Fluent;
using EfCoreDemo.Model.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<AuthorBookRelation> AuthorsBooks { get; set; }

        // Fluent API
        public DbSet<BookDetailFluent> BookDetails_Fluent { get; set; }
        public DbSet<BookFluent> Books_Fluent { get; set; }
        public DbSet<AuthorFluent> Authors_Fluent { get; set; }
        public DbSet<PublisherFluent> Publishers_Fluent { get; set; }

        // Views
        public DbSet<BookDetailView> BookDetailView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // options.UseSqlServer("Server=.;Database=EfCoreDemo;TrustServerCertificate=True;Trusted_Connection=True;")
               // .LogTo(Console.WriteLine, new [] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookDetailEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorBookRelationEntityConfiguration());


            modelBuilder.Entity<Book>().Property(p => p.Price).HasPrecision(10, 5);
            modelBuilder.Entity<AuthorBookRelation>().HasKey(k => new { k.AuthorId, k.BookId });

            // Configure View
            modelBuilder.Entity<BookDetailView>().HasNoKey().ToView("GetOnlyBookDetails");

            /// Seed Data
            var publishers = new Publisher[]
            {
                new Publisher { Publisher_Id=1, Name="Pearson", Location="USA" },
                new Publisher { Publisher_Id=2, Name="OReily", Location="UK" },
            };
            modelBuilder.Entity<Publisher>().HasData(publishers);

            var books = new Book[] 
            {
                new Book { Id=1, Title="Conan The Barbarian", ISBN="77VG", Price=99.5m, Publisher_Id=1 },
                new Book { Id=2, Title="Beautiful Worl", ISBN="43TY", Price=50.25m, Publisher_Id=2 },
                new Book { Id=3, Title="Its Complicated", ISBN="93BH", Price=17.15m, Publisher_Id=2 },
            };
            modelBuilder.Entity<Book>().HasData(books);
        }
    }
}
