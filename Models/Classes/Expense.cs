﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}