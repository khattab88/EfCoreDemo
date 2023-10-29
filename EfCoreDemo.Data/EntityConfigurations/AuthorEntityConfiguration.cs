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
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<AuthorFluent>
    {
        public void Configure(EntityTypeBuilder<AuthorFluent> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Authors");
            modelBuilder.HasKey(p => p.Author_Id);
            modelBuilder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Property(p => p.LastName).IsRequired();
            modelBuilder.Ignore(p => p.FullName);
        }
    }
}
