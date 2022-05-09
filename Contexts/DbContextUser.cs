using Microsoft.EntityFrameworkCore;
using arnuv_api.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace arnuv_api.Contexts
{
    public class DbContextUser :DbContext
    {
        public DbContextUser(DbContextOptions<DbContextUser> options) : base(options)
        {
        }
        //public DbSet<UserResponse> UserResponse { get; set; }
        public DbSet<User> User { get; set; }

        /*public IQueryable<UserResponse> UserMethod(UserResponse field)
        {
            var parameters = new[]
                {
                    new SqlParameter("@command", System.Data.SqlDbType.VarChar, 4) { Value = field.command },
                    new SqlParameter("@email_user", System.Data.SqlDbType.VarChar, 100) { Value = field.emailUser},
                    new SqlParameter("@id_role", System.Data.SqlDbType.Int, 20) { Value = field.idRole},
                    new SqlParameter("@id_user", System.Data.SqlDbType.BigInt, 20) { Value = field.idUser},
                    new SqlParameter("@isavailable_user", System.Data.SqlDbType.Bit, 20) { Value = field.isavailableUser},
                    new SqlParameter("@lastname_user", System.Data.SqlDbType.VarChar, 100) { Value = field.lastnameUser},
                    new SqlParameter("@name_user", System.Data.SqlDbType.VarChar, 100) { Value = field.nameUser},
                    new SqlParameter("@password_user", System.Data.SqlDbType.VarChar, 200) { Value = field.passwordUser},
                };
            var resultado = this.UserResponse.FromSqlRaw("pro_User @command,@email_user,@id_role,@id_user,@isavailable_user,@lastname_user,@name_user,@password_user", parameters.ToArray());
            return resultado;
            
        }*/
    }
}
