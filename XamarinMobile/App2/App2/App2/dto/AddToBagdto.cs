using System;
using System.Collections.Generic;
using System.Text;

namespace App2.dto
{
    public class AddToBagdto
    {
        public string BookAuthor { get; set; }

        public string BookImage { get; set; }

        public string BookTitle { get; set; }

        public int BookId { get; set; }

        public int BookQuantity { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
