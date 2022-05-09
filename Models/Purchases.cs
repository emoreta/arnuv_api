using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("purchases")]
    public class Purchases
    {
        [Column("code_provider")]
        public string codeprovider { get; set; }
        [Column("date_created_purchases")]
        public DateTime datecreatedpurchases { get; set; }
        [Column("date_document_purchases")]
        public DateTime datedocumentpurchases { get; set; }
        [Column("detail_invoice_purchases")]
        public string detailinvoicepurchases { get; set; }
        [Column("detail_seat_purchases")]
        public string detailseatpurchases { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_purchases")]
        public Int64 idpurchases { get; set; }
        [Column("id_type_payments")]
        public string idtypepayments { get; set; }
        [Column("isavailable_purchase")]
        public Boolean isavailablepurchase { get; set; }
        [Column("iva_invoice_purchases")]
        public decimal ivainvoicepurchases { get; set; }
        [Column("number_autorization_invoice_purchases")]
        public string numberautorizationinvoicepurchases { get; set; }
        [Column("number_invoice_purchases")]
        public string numberinvoicepurchases { get; set; }
        [Column("sub_total_invoice_purchases")]
        public decimal subtotalinvoicepurchases { get; set; }
        [Column("total_purchases")]
        public decimal totalpurchases { get; set; }
    }
}
