using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace arnuv_api.Models
{
    [Table("file")]
    public class File
    {
        [Column("id_file")]
        public int idfile { get; set; }
        [Column("extension_file")]
        public string extensionfile { get; set; }
        [Column("name_file")]
        public string namefile { get; set; }
        [Column("path_file")]
        public string pathfile { get; set; }
    }
}
