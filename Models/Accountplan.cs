using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("account_plan")]
    public class Accountplan
    {
        [Column("balance_account_plan")]
        public string balanceaccountplan { get; set; }
        [Column("code_account_plan")]
        public string codeaccountplan { get; set; }
        [Column("created_account_plan")]
        public DateTime createdaccountplan { get; set; }
        [Column("detail_account_plan")]
        public string detailaccountplan { get; set; }
        [Key]
        [Column("id_account_plan")]
        public int idaccountplan { get; set; }
        [Column("id_children_account_plan")]
        public int idchildrenaccountplan { get; set; }
        [Column("id_parent_account_plan")]
        public int idparentaccountplan { get; set; }
        [Column("isavailable_account_plan")]
        public Boolean isavailableaccountplan { get; set; }
        [Column("level_account_plan")]
        public int levelaccountplan { get; set; }
    }
}
