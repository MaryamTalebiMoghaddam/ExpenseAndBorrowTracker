﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseAndBorrowTracker.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }
        [DisplayName("Item name")]
        public string Itemname { get; set; }
    }
}