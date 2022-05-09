using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("account_pay")]
    public class Accountpay
    {
        [Column("code_currency")]
        public string codecurrency { get; set; }
        [Column("code_provider")]
        public string codeprovider { get; set; }
        [Column("date_account_pay")]
        public DateTime dateaccountpay { get; set; }
        [Column("date_created_pay_account")]
        public DateTime datecreatedpayaccount { get; set; }
        [Column("number_one_account_pay")]
        public string numberoneaccountpay { get; set; }
        [Column("number_two_account_pay")]
        public string numbertwoaccountpay { get; set; }
        [Column("observation_account_pay")]
        public string observationaccountpay { get; set; }
        [Column("referent_account_pay")]
        public string referentaccountpay { get; set; }
    }
}
