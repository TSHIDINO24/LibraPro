using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = null;

        public string BookAuthor { get; set; } = null;

        public string BookDescription { get; set; } = null;

        public string BookStatus { get; set; }

        public string Isbn { get; set; }

        public string CategoryName { get; set; }

        public int BookQuantity { get; set; } 

        public string BookImage { get; set; } = null;

        public int CategoryID { get; set; }
    }
}
