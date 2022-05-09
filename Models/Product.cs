using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("id_product")]
        public Int16 idproduct { get; set; }
        [Column("code_currency")]
        public string codecurrency { get; set; }
        [Column("code_iva")]
        public string codeiva { get; set; }
        [Column("code_product")]
        public string codeproduct { get; set; }
        [Column("code_storage")]
        public string codestorage { get; set; }
        [Column("name_product")]
        public string nameproduct { get; set; }
        [Column("observation_product")]
        public string observationproduct { get; set; }
        [Column("price_a")]
        public double pricea { get; set; }
        [Column("price_b")]
        public double priceb { get; set; }
        [Column("price_c")]
        public double pricec { get; set; }

        [Column("discount_percentage_a")]
        public double discountpercentagea { get; set; }
        [Column("discount_percentage_b")]
        public double discountpercentageb { get; set; }
        [Column("discount_percentage_c")]
        public double discountpercentagec { get; set; }

        [Column("ice_product")]
        public double iceproduct { get; set; }
        [Column("stock")]
        public Int16 stock { get; set; }

    }
}
