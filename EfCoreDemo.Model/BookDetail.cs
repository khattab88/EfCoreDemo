using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.Model
{
    public class BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }
        public int NumOfChapters { get; set; }
        public int NumOfPages { get; set; }
        public double Weight { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
