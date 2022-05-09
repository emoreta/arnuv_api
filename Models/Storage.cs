using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("storage")]
    public class Storage
    {
        [Key]
        [Column("code_storage")]
        public string codestorage { get; set; }
        [Column("isavailable_storage")]
        public Boolean isavailablestorage { get; set; }
        [Column("name_storage")]
        public string namestorage { get; set; }
    }
}
