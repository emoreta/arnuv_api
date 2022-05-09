using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("account_bank")]
    public class Accountbank
    {
        [Column("cta_account_bank")]
        public string ctaaccountbank { get; set; }
        [Key]
        [Column("id_account_bank")]
        public int idaccountbank { get; set; }
        [Column("locked_account_bank")]
        public Boolean lockedaccountbank { get; set; }
        [Column("name_account_bank")]
        public string nameaccountbank { get; set; }
        [Column("number_account_bank")]
        public string numberaccountbank { get; set; }
    }
}
