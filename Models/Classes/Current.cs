using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "You can write max 30 character")]
        public string CurrentName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="You can not pass this area!")]
        public string CurrentSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }
        public bool Status { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}