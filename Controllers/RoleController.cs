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
    public class RoleController : ControllerBase
    {
        private DbContextRole _dbContextRole;
        public RoleController(DbContextRole context)
        {
            _dbContextRole = context;
        }
        [HttpGet]
        [Route("getRole/")]
        public ActionResult<IEnumerable<Role>> Get()
        {
            return _dbContextRole.Role.Where(s=>s.isavailablerole==true).ToList();
        }


        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Role> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Role id must be higher than zero");
            }
            Role ob = _dbContextRole.Role.FirstOrDefault(s => s.idrole == id);
            if (ob == null)
            {
                return NotFound(" Role not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Role role)
        {
            if (role == null)
            {
                return NotFound("role data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRole.Role.AddAsync(role);
            await _dbContextRole.SaveChangesAsync();
            return Ok(role);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Role role)
        {
            if (role == null)
            {
                return NotFound("role data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Role ob = _dbContextRole.Role.FirstOrDefault(s => s.idrole == role.idrole);
            if (ob == null)
            {
                return NotFound("Role does not exist in the database");
            }
            ob.descriptionrole = role.descriptionrole;
            ob.idrole = role.idrole;
            ob.isavailablerole = role.isavailablerole;
            ob.namerole = role.namerole;
            _dbContextRole.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRole.SaveChangesAsync();
            return Ok(ob);
        }
    }
}
