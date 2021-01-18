using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizlib_model.models
{
    public class Publisher
    {
        [Key]
        public int Publisher_Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public  string Location { get; set; }
        public List<Book> Books { get; set; }
    }
}
