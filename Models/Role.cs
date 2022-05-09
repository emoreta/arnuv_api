using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_role")]
        public Int16 idrole { get; set; }
        [Column("description_role")]
        public string descriptionrole { get; set; }
        [Column("isavailable_role")]
        public Boolean isavailablerole { get; set; }
        [Column("name_role")]
        public string namerole { get; set; }
    }
}
