using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("role_menu")]
    public class Rolemenu
    {
        [Column("isavailable_role_menu")]
        public Boolean isavailablerolemenu { get; set; }
        [Column("id_role")]
        public Int16 idrole { get; set; }

        [Key]
        [Column("id_role_menu")]
        public Int16 idrolemenu { get; set; }

        [Column("id_menu")]
        public Int16 idmenu { get; set; }
        [NotMapped]
        [Column("name_menu")]
        public string namemenu { get; set; }
        [NotMapped]
        [Column("name_role")]
        public string namerole { get; set; }

    }
}
