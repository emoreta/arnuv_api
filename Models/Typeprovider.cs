using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("type_provider")]
    public class Typeprovider
    {
        [Key]
        [Column("code_type_provider")]
        public string codetypeprovider { get; set; }
        [Column("cta_type_provider")]
        public string ctatypeprovider { get; set; }
        [Column("isavailable_type_provider")]
        public Boolean isavailabletypeprovider { get; set; }
        [Column("name_type_provider")]
        public string nametypeprovider { get; set; }
    }
}
