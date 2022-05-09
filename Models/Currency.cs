using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("currency")]
    public class Currency
    {
        [Key]
        [Column("code_currency")]
        public string codecurrency { get; set; }
        [Column("name_currency")]
        public string namecurrency { get; set; }
        [Column("symbol_currency")]
        public string symbolcurrency { get; set; }
    }
}

