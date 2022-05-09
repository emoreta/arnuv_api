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
    public class RolemenuController : ControllerBase
    {
        private DbContextArnuv _dbContextRolemenu;
        public RolemenuController(DbContextArnuv context)
        {
            _dbContextRolemenu = context;
        }
        [HttpGet]
        [Route("getRolemenu/")]
        public ActionResult<IEnumerable<Rolemenu>> Get()
        {
            //return _dbContextRolemenu.Rolemenu.ToList();
            IEnumerable<Rolemenu> query =
                       //from procesoDiario in _dbContextTcontdetalle.Tcontprocesodiario
                       from rolemenu in _dbContextRolemenu.Rolemenu
                       join role in _dbContextRolemenu.Role on rolemenu.idrole equals role.idrole
                       join menu in _dbContextRolemenu.Menu on rolemenu.idmenu equals menu.idmenu
                       where rolemenu.isavailablerolemenu == true
                       select new Rolemenu
                       {
                           isavailablerolemenu = rolemenu.isavailablerolemenu,
                           idrole = rolemenu.idrole,
                           idrolemenu = rolemenu.idrolemenu,
                           idmenu = rolemenu.idmenu,
                           namemenu = menu.namemenu,
                           namerole = role.namerole,
                       };

            return query.OrderByDescending(x => x.idrolemenu).ToList();

        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Rolemenu> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Rolemenu id must be higher than zero");
            }
            Rolemenu ob = _dbContextRolemenu.Rolemenu.FirstOrDefault(s => s.idrolemenu == id);
            if (ob == null)
            {
                return NotFound(" Rolemenu not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Rolemenu rolemenu)
        {
            if (rolemenu == null)
            {
                return NotFound("rolemenu data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextRolemenu.Rolemenu.AddAsync(rolemenu);
            await _dbContextRolemenu.SaveChangesAsync();
            return Ok(rolemenu);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Rolemenu rolemenu)
        {
            if (rolemenu == null)
            {
                return NotFound("rolemenu data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Rolemenu ob = _dbContextRolemenu.Rolemenu.FirstOrDefault(s => s.idrolemenu == rolemenu.idrolemenu);
            if (ob == null)
            {
                return NotFound("Rolemenu does not exist in the database");
            }
            ob.idmenu = rolemenu.idmenu;
            ob.idrole = rolemenu.idrole;
            ob.idrolemenu = rolemenu.idrolemenu;
            ob.isavailablerolemenu = rolemenu.isavailablerolemenu;
            _dbContextRolemenu.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextRolemenu.SaveChangesAsync();
            return Ok(ob);
        }
    }
}
