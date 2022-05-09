using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("detail_purchases")]
    public class Detailpurchases
    {
        [Column("date_created_purchases")]
        public DateTime datecreatedpurchases { get; set; }
        [Column("description_detail_puchases")]
        public string descriptiondetailpuchases { get; set; }
        [Column("id_account_plan")]
        public int idaccountplan { get; set; }
        [Key]
        [Column("id_detail_purchases")]
        public Int64 iddetailpurchases { get; set; }
        [Column("id_purchases")]
        public Int64 idpurchases { get; set; }
        [Column("quantity_detail_purchases")]
        public decimal quantitydetailpurchases { get; set; }
        [Column("value_total_detail_purchases")]
        public decimal valuetotaldetailpurchases { get; set; }
        [Column("value_unitary_detail_purchases")]
        public decimal valueunitarydetailpurchases { get; set; }
        [Column("isavailable")]
        public Boolean isavailable { get; set; }
        [Column("date_updated_detail_purchases")]
        public DateTime dateupdateddetailpurchases { get; set; }
        [Column("iva_detail_purchases")]
        public decimal ivadetailpurchases { get; set; }
    }
}
