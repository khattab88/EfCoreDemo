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
    public class PublisherEntityConfiguration : IEntityTypeConfiguration<PublisherFluent>
    {
        public void Configure(EntityTypeBuilder<PublisherFluent> modelBuilder)
        {
            // Publishers
            modelBuilder.ToTable("Fluent_Publishers");
            modelBuilder.HasKey(p => p.Publisher_Id);
            modelBuilder.Property(p => p.Name).IsRequired();
        }
    }
}
