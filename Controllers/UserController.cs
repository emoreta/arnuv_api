using arnuv_api.Contexts;
using arnuv_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arnuv_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private DbContextArnuv _dbContextUser;
        public UserController(DbContextArnuv context)
        {
            _dbContextUser = context;
        }

        [HttpGet]
        [Route("getUser/")]
        public ActionResult<IEnumerable<User>> Get()
        {
            //return _dbContextUser.User.Where(s=>s.isavailableuser==true).ToList();
            IEnumerable<User> query =
                       //from procesoDiario in _dbContextTcontdetalle.Tcontprocesodiario
                       from user in _dbContextUser.User
                           join role in _dbContextUser.Role on user.idrole equals role.idrole
                           /*join estadoDetalle in _dbContextTcontdetalle.Tcontestado on detalle.idestado equals estadoDetalle.idestado
                           join homologacion in _dbContextTcontdetalle.Tconthomologacioncausal on detalle.codigorespuestaarchivodetalle equals homologacion.id*/
                       where user.isavailableuser == true
                       select new User
                       {
                           iduser = user.iduser,
                           emailuser = user.emailuser,
                           isavailableuser = user.isavailableuser,
                           lastnameuser = user.lastnameuser,
                           nameuser = user.nameuser,
                           passworduser = user.passworduser,
                           idrole = user.idrole,
                           birthdateuser = user.birthdateuser,
                           phoneuser = user.phoneuser,
                           createduser = user.createduser,
                           updateduser = user.updateduser,
                           namerole = role.namerole,


                       };

            return query.OrderByDescending(x => x.iduser).ToList();
        }

       /* [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> Get()
        {
            UserResponse us = new UserResponse
            {
                command = "SELA",
                idUser = 0,
                idRole = 0,
                isavailableUser = false,
                lastnameUser = "",
                passwordUser = "",
                nameUser = "",
                emailUser = ""
            };
            return _dbContextUser.UserMethod(us).ToList();
        }*/
        [HttpGet]

        [Route("getbyid/{id}")]
        public ActionResult<UserResponse> GetById(int id)
        {
            if (id==0)
            {
                return NotFound("Persona id must be higher than zero");
            }
            User us = _dbContextUser.User.FirstOrDefault(s => s.iduser == id);
            if (us == null)
            {
                return NotFound("User not found");
            }
            return Ok(us);
        }
        [HttpPost]
        [Route("login/")]
        public ActionResult<UserRes> Login([FromBody] User usuario)
        {
            UserRes ur = new UserRes();
            ur.message = "";
            ur.stateLogin = false;

            if (usuario == null)
            {
                //return NotFound("Persona id must be higher than zero");
                ur.message = "sin usuario";
                ur.stateLogin = false;
            }
            User us = _dbContextUser.User.FirstOrDefault(s => s.emailuser == usuario.emailuser && s.passworduser==usuario.passworduser && s.isavailableuser==true);
            if (us == null)
            {
                //return NotFound("User not found");
                ur.message = "User not found";
                ur.stateLogin = false;

            }
            else
            {
                ur.message = "OK";
                ur.stateLogin = true;
                ur.idrole = us.idrole;
                ur.nameuser = us.nameuser;
                ur.lastnameuser = us.lastnameuser;
            }
            return Ok(ur);
        }


        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] User usuario)
        {
            if (usuario == null)
            {
                return NotFound("Persona data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextUser.User.AddAsync(usuario);
            await _dbContextUser.SaveChangesAsync();
            return Ok(usuario);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody]User user)
        {
            if (user == null)
            {
                return NotFound("Stduent data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User existingUser = _dbContextUser.User.FirstOrDefault(s => s.iduser == user.iduser);
            if (existingUser == null)
            {
                return NotFound("User does not exist in the database");
            }
            existingUser.idrole = user.idrole;
            existingUser.emailuser = user.emailuser;
            existingUser.isavailableuser = user.isavailableuser;
            existingUser.lastnameuser = user.lastnameuser;
            existingUser.nameuser = user.nameuser;
            existingUser.passworduser = user.passworduser;
            existingUser.birthdateuser = user.birthdateuser;
            existingUser.phoneuser = user.phoneuser;
            existingUser.createduser = user.createduser;
            existingUser.updateduser = user.updateduser;
            existingUser.iduser = user.iduser;


            _dbContextUser.Attach(existingUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextUser.SaveChangesAsync();
            return Ok(existingUser);
        }

    }
}
