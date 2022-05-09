using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("menu")]
    public class Menu
    {
        [Column("icon_menu")]
        public string iconmenu { get; set; }
        [Column("isavailable_menu")]
        public Boolean isavailablemenu { get; set; }
        [Column("name_menu")]
        public string namemenu { get; set; }
        [Column("page_menu")]
        public string pagemenu { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_menu")]
        public Int16 idmenu { get; set; }
        [Column("parent_node_menu")]
        public Int16 parentnodemenu { get; set; }
        [Column("child_node_menu")]
        public Int16 childnodemenu { get; set; }

        [NotMapped]
        public List<Menu> menuChild { get; set; }
    }

    public class MenuSimple
    {
        [Column("icon_menu")]
        public string iconmenu { get; set; }
        [Column("isavailable_menu")]
        public Boolean isavailablemenu { get; set; }
        [Column("name_menu")]
        public string namemenu { get; set; }
        [Column("page_menu")]
        public string pagemenu { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_menu")]
        public Int16 idmenu { get; set; }
        [Column("parent_node_menu")]
        public Int16 parentnodemenu { get; set; }
        [Column("child_node_menu")]
        public Int16 childnodemenu { get; set; }

      
    }
}
