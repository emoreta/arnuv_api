using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("additional_costs")]
    public class Additionalcosts
    {
        [Column("code_additional_cost")]
        public string codeadditionalcost { get; set; }
        [Column("id_additional_cost")]
        public int idadditionalcost { get; set; }
        [Column("isavailable_additional_costs")]
        public Boolean isavailableadditionalcosts { get; set; }
        [Column("name_additional_costs")]
        public string nameadditionalcosts { get; set; }
        [Column("value_additional_costs")]
        public decimal valueadditionalcost { get; set; }
    }
}
