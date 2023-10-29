using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.Model.Fluent
{
    public class PublisherFluent
    {
        // [Key]
        public int Publisher_Id { get; set; }
        // [Required]
        public string Name { get; set; }
        public string Location { get; set; }

        public List<BookFluent> Books { get; set; }
    }
}
