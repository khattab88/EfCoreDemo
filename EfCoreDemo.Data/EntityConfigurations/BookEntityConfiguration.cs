using EfCoreDemo.Model.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.Data.EntityConfigurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<BookFluent>
    {
        public void Configure(EntityTypeBuilder<BookFluent> modelBuilder)
        {
            // Books
            modelBuilder.ToTable("Fluent_Books");
            modelBuilder.HasKey(p => p.Id);
            modelBuilder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Property(p => p.ISBN).IsRequired().HasMaxLength(10);
            modelBuilder.Property(p => p.Price).IsRequired();
            modelBuilder.Ignore(p => p.PriceRange);
            modelBuilder.HasOne(b => b.Publisher).WithMany(p => p.Books)
                .HasForeignKey(b => b.Publisher_Id);
        }
    }
}
