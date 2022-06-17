using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{    
    // [Table("Libraries")]
    public class Library
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibId { get; set; }

        public string LibName { get; set; }

        public virtual ICollection<Book> LibBooks { get; set; } = new List<Book>();

        [NotMapped]
        public IEnumerable<Stock> LibStock
            => LibBooks.GroupBy(b => b.Title, (title, bookgroup) => new Stock { Title = title, StockQty = bookgroup.Count() } ) ;


    }


}
