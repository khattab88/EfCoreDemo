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
    public class BookDetailEntityConfiguration : IEntityTypeConfiguration<BookDetailFluent>
    {
        public void Configure(EntityTypeBuilder<BookDetailFluent> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookDetails");
            modelBuilder.HasKey(p => p.BookDetail_Id);
            modelBuilder.Property(p => p.NumOfChapters).IsRequired();
            modelBuilder.Property(p => p.NumOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.HasOne(d => d.Book).WithOne(b => b.BookDetail)
                .HasForeignKey<BookDetailFluent>(d => d.BookId);
        }
    }
}
