using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("credit_type")]
    public class Credittype
    {
        [Column("id_credit_type")]
        public int idcredittype { get; set; }
        [Column("code_credit_type")]
        public string codecredittype { get; set; }
        [Column("credit_type")]
        public string credittype { get; set; }
        [Column("isavailable_credit_type")]
        public Boolean isavailablecredittype { get; set; }
    }
}
