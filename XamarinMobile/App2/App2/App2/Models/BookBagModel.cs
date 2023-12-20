using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class BookBagModel
    {
        public int BagId { get; set; }
        public int Id { get; set; }
        public string BookTitle { get; set; } = null;

        public string BookAuthor { get; set; } = null;

        public string BookDescription { get; set; } = null;

        public string Status { get; set; }

        public int BookQuantity { get; set; }

        public string BookImage { get; set; } = null;

        public int CategoryID { get; set; }
         
        public string CategoryName { get; set; }
    }
}
