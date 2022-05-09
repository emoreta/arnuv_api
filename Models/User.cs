using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace arnuv_api.Models
{
    public class UserResponse
    {

        [Key]
        [Column("id_user")]
        public Int64 iduser { get; set; }
        [NotMapped]
        public string command { get; set; }
        [Column("email_user")]
        public string emailuser { get; set; }
        [Column("isavailable_user")]
        public Boolean isavailableuser { get; set; }
        [Column("lastname_user")]
        public string lastnameuser { get; set; }
        [Column("name_user")]
        public string nameuser { get; set; }
        [Column("password_user")]
        public string passworduser { get; set; }
        [Column("id_role")]
        public Int16 idrole { get; set; }
   
    }
    public class UserRes
    {

        
        
        public string message { get; set; }
        
        public Boolean stateLogin { get; set; }

        public Int16 idrole { get; set; }

        public string nameuser { get; set; }

        public string lastnameuser { get; set; }

    }
    public class User
    {

        [Key]
        [Column("id_user")]
        public Int64 iduser { get; set; }
        [Column("email_user")]
        public string emailuser { get; set; }
        [Column("isavailable_user")]
        public Boolean isavailableuser { get; set; }
        [Column("lastname_user")]
        public string lastnameuser { get; set; }
        [Column("name_user")]
        public string nameuser { get; set; }
        [Column("password_user")]
        public string passworduser { get; set; }
        [Column("id_role")]
        public Int16 idrole { get; set; }

        [Column("birth_date_user")]
        public DateTime birthdateuser { get; set; }
        [Column("phone_user")]
        public string phoneuser { get; set; }
        [Column("created_user")]
        public DateTime createduser { get; set; }
        [Column("updated_user")]
        public DateTime updateduser { get; set; }
        [NotMapped]
        [Column("name_role")]
        public string namerole { get; set; }

    }
}
