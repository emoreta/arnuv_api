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
    public class TypeproviderController : ControllerBase
    {
        private DbContextArnuv _dbContextTypeprovider;
        public TypeproviderController(DbContextArnuv context)
        {
            _dbContextTypeprovider = context;
        }
        [HttpGet]
        [Route("getTypeprovider/")]
        public ActionResult<List<Typeprovider>> Get()
        {
            return _dbContextTypeprovider.Typeprovider.Where(s=>s.isavailabletypeprovider==true).ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Typeprovider> Get(string id)
        {
            if (id == "")
            {
                return NotFound("Typeprovider id must be higher than zero");
            }
            Typeprovider ob = _dbContextTypeprovider.Typeprovider.FirstOrDefault(s => s.codetypeprovider == id);
            if (ob == null)
            {
                return NotFound(" Typeprovider not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Typeprovider typeprovider)
        {
            if (typeprovider == null)
            {
                return NotFound("typeprovider data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextTypeprovider.Typeprovider.AddAsync(typeprovider);
            await _dbContextTypeprovider.SaveChangesAsync();
            return Ok(typeprovider);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Typeprovider typeprovider)
        {
            if (typeprovider == null)
            {
                return NotFound("typeprovider data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Typeprovider ob = _dbContextTypeprovider.Typeprovider.FirstOrDefault(s => s.codetypeprovider == typeprovider.codetypeprovider);
            if (ob == null)
            {
                return NotFound("Typeprovider does not exist in the database");
            }
            ob.codetypeprovider = typeprovider.codetypeprovider;
            ob.ctatypeprovider = typeprovider.ctatypeprovider;
            ob.isavailabletypeprovider = typeprovider.isavailabletypeprovider;
            ob.nametypeprovider = typeprovider.nametypeprovider;
            _dbContextTypeprovider.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextTypeprovider.SaveChangesAsync();
            return Ok(_dbContextTypeprovider);
        }
    }
}
