using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("type_payments")]
    public class Typepayments
    {
        [Column("description_type_payments")]
        public string descriptiontypepayments { get; set; }

        [Key]
        [Column("id_type_payments")]
        public string idtypepayments { get; set; }
        [Column("isavailable_type_payments")]
        public Boolean isavailabletypepayments { get; set; }
    }
}
