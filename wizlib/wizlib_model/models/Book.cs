using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wizlib_model.models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(15)]
        public string ISBN { get; set; }
        [Required]
        public double Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }
        [ForeignKey("BookDetail")]
        public int? BookDetail_Id { get; set; }
        public BookDetail BookDetail { get; set; }
        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BookAuthor> bookAuthors { get; set; }
        public Category category { get; set; }
    }
}
