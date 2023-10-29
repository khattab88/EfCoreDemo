using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.Model.Fluent
{
    public class BookFluent
    {
        // [Key]
        public int Id { get; set; }

        // [Required]
        // [MaxLength(50)]
        public string Title { get; set; }

        // [Required]
        // [MaxLength(10)]
        public string ISBN { get; set; }

        // [Required]
        public decimal Price { get; set; }

        // [NotMapped]
        public string PriceRange { get; set; }

        public BookDetailFluent BookDetail { get; set; }

        //[ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public PublisherFluent Publisher { get; set; }

        // public List<AuthorConfiguration> Authors { get; set; }

        public List<AuthorBookRelationFluent> AuthorsBooks { get; set; }
    }
}
