using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace arnuv_api.Models
{
    [Table("iva")]
    public class Iva
    {
        [Key]
        [Column("code_iva")]
        public string codeIva { get; set; }

        [Column("percentage_iva")]
        public decimal percentageIva { get; set; }

        [Column("isavailable_iva")]
        public Boolean isavailableIva { get; set; }
    }
}
