using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    public class BorrowedModel
    {
        public int BorrowedId { get; set; }

        public int BagId { get; set; }

        public string BookTitle { get; set; } = null;

        public string BookAuthor { get; set; } = null;

        public string BookImage { get; set; } = null;

        public string BorrowCode { get; set; } = null;

        public DateTime? BorrowDate { get; set; } 

        public DateTime? BorrowReturnedDate { get; set; }

        public string Status { get; set; } = null;
    }
}
