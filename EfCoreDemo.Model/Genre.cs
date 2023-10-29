using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreDemo.Model
{
    [Table("Categories")]
    public class Genre
    {
        public int Id { get; set; }
        // [Column("col_name")]
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
