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
    public class AuthorBookRelationEntityConfiguration : IEntityTypeConfiguration<AuthorBookRelationFluent>
    {
        public void Configure(EntityTypeBuilder<AuthorBookRelationFluent> modelBuilder)
        {
            // AuthorsBooksRelation
            modelBuilder.ToTable("Fluent_AuthorsBooks");
            modelBuilder.HasKey(k => new { k.AuthorId, k.BookId });
            modelBuilder.HasOne(p => p.Author).WithMany(a => a.AuthorsBooks)
                .HasForeignKey(p => p.AuthorId);
            modelBuilder.HasOne(p => p.Book).WithMany(b => b.AuthorsBooks)
                .HasForeignKey(p => p.BookId);
        }
    }
}
