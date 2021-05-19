﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Note { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}