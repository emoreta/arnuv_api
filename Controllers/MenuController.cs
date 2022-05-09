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
    public class MenuController : ControllerBase
    {
        private DbContextMenu _dbContextMenu;
        public MenuController(DbContextMenu context)
        {
            _dbContextMenu = context;
        }
        [HttpGet]
        [Route("getMenu/")]
        public ActionResult<IEnumerable<Menu>> Get(int idRole)
        {
            //return _dbContextMenu.Menu.ToList();

            IEnumerable<Menu> query =
                       //from procesoDiario in _dbContextTcontdetalle.Tcontprocesodiario
                       from menu in _dbContextMenu.Menu
                       join role_menu in _dbContextMenu.RolMenu on menu.idmenu equals role_menu.idmenu
                       where menu.childnodemenu == 0 && role_menu.idrole== idRole && menu.isavailablemenu==true
                       select new Menu
                       {
                           idmenu = menu.idmenu,
                           parentnodemenu = menu.parentnodemenu,
                           childnodemenu = menu.childnodemenu,
                           namemenu = menu.namemenu,
                           pagemenu = menu.pagemenu,
                           iconmenu = menu.iconmenu,
                           isavailablemenu = menu.isavailablemenu,
                           menuChild = _dbContextMenu.Menu.Where(x => x.parentnodemenu == menu.parentnodemenu && x.childnodemenu != 0 && x.isavailablemenu==true ).ToList()
                       };

            return query.ToList();
        }

        [HttpGet]
        [Route("getMenuCompleto/")]
        public ActionResult<IEnumerable<Menu>> GetMenuCompleto()
        {
            return _dbContextMenu.Menu.Where(s=>s.isavailablemenu==true).ToList();

        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Menu> GetRes(int id)
        {
            if (id == 0)
            {
                return NotFound("Menu id must be higher than zero");
            }
            Menu ob = _dbContextMenu.Menu.FirstOrDefault(s => s.idmenu == id);
            if (ob == null)
            {
                return NotFound(" Menu not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] MenuSimple menu)
        {
            if (menu == null)
            {
                return NotFound("menu data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextMenu.MenuSimple.AddAsync(menu);
            await _dbContextMenu.SaveChangesAsync();
            return Ok(menu);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Menu menu)
        {
            if (menu == null)
            {
                return NotFound("menu data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Menu ob = _dbContextMenu.Menu.FirstOrDefault(s => s.idmenu == menu.idmenu);
            if (ob == null)
            {
                return NotFound("Menu does not exist in the database");
            }
            ob.childnodemenu = menu.childnodemenu;
            ob.iconmenu = menu.iconmenu;
            ob.idmenu = menu.idmenu;
            ob.isavailablemenu = menu.isavailablemenu;
            ob.namemenu = menu.namemenu;
            ob.pagemenu = menu.pagemenu;
            ob.parentnodemenu = menu.parentnodemenu;
            _dbContextMenu.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextMenu.SaveChangesAsync();
            return Ok(_dbContextMenu);
        }
    }
}
