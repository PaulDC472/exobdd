using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        public string Title{ get; set; }

        public int PageCount { get; set; }  

        public int? SimilaryBookId { get; set; } 
        public virtual Book SimilaryBook { get; set; }  

        public virtual ICollection<User> Readers { get; set; } = new List<User>();

    }
}
