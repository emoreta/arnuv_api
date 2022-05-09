using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace arnuv_api.Models
{
    [Table("provider")]
    public class Provider
    {
        [Key]
        [Required]
        [Column("code_provider")]
        public string? codeprovider { get; set; }
        [Column("address_provider")]
        [DefaultValue("")]
        [Required]
        public string? addressprovider { get; set; }
        [Column("code_iva")]
        [DefaultValue("")]
        public string? codeiva { get; set; }
        
        [Column("code_type_provider")]
        [DefaultValue("")]
        public String codetypeprovider { get; set; }
        [Column("comment_provider")]
        [DefaultValue("")]
        public string? commentprovider { get; set; }
        [Column("cta_provider")]
        [DefaultValue("")]
        public string? ctaprovider { get; set; }
        [Column("deadlines_provider")]
        [DefaultValue(0)]
        public int deadlinesprovider { get; set; }
        [Column("email_provider")]
        [DefaultValue("")]
        
        public string? emailprovider { get; set; }
        [Column("identification_provider")]
        [DefaultValue("")]
        public string? identificationprovider { get; set; }
        [Column("name_provider")]
        [DefaultValue("")]
        public string? nameprovider { get; set; }
        [Column("telephone_one_provider")]
        [DefaultValue("")]
        public string? telephoneoneprovider { get; set; }
        [Column("telephone_two_provider")]
        [DefaultValue("")]
        public string? telephonetwoprovider { get; set; }
        [Column("discount_provider")]
        [DefaultValue(0)]
        public decimal discountprovider { get; set; }
        [Column("current_balance")]
        public decimal currentbalance { get; set; }
    }
}
