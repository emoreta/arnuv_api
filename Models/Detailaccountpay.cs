using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("detail_account_pay")]
    public class Detailaccountpay
    {
        [Column("id_detail_account_pay")]
        public int iddetailaccountpay { get; set; }
        [Column("code_detail_accoun_pay")]
        public string codedetailaccounpay { get; set; }
        [Column("name_detail_account_pay")]
        public string namedetailaccountpay { get; set; }

        [Column("quanity_detail_account_pay")]
        public int quanitydetailaccountpay { get; set; }
        [Column("amount_detail_account_pay")]
        public decimal amountdetailaccountpay { get; set; }
        [Column("discount_detail_account_pay")]
        public decimal discountdetailaccountpay { get; set; }
        [Column("total_detail_account_pay")]
        public decimal totaldetailaccountpay { get; set; }
        [Column("id_account_pay")]
        public decimal idaccountpay { get; set; }
    }
}
