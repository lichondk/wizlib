using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wizlib_model.models;

namespace wizlib_model.ViewModels
{
    public class BookAuthorVM
    {
        public BookAuthor BookAuthor { get; set; }
        public Book Book { get; set; }
        public IEnumerable<BookAuthor> bookAuthorList { get; set; }
        public IEnumerable<SelectListItem> Authorlist { get; set; }
    }
}
