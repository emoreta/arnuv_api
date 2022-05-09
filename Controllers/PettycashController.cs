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
    [Route("[controller]")]
    public class PettycashController : ControllerBase
    {
        /*private DbContextPettycash _dbContextPettycash;
        public PettycashController(DbContextPettycash context)
        {
            _dbContextPettycash = context;
        }
        [HttpGet]
        [Route("getPettycash/ ")]
        public ActionResult<List<Pettycash>> Get()
        {
            return _dbContextPettycash.Pettycash.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Pettycash> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Pettycash id must be higher than zero");
            }
            Pettycash ob = _dbContextPettycash.Pettycash.FirstOrDefault(s => s.codeIva == id);
            if (ob == null)
            {
                return NotFound(" Pettycash not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Pettycash pettycash)
        {
            if (pettycash == null)
            {
                return NotFound("pettycash data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextPettycash.Pettycash.AddAsync(pettycash);
            await _dbContextPettycash.SaveChangesAsync();
            return Ok(pettycash);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Pettycash pettycash)
        {
            if (pettycash == null)
            {
                return NotFound("pettycash data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Pettycash ob = _dbContextPettycash.Pettycash.FirstOrDefault(s => s.codeIva == pettycash.codeIva);
            if (ob == null)
            {
                return NotFound("Pettycash does not exist in the database");
            }
            ob.idpettycash = pettycash.idpettycash;
            _dbContextPettycash.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextPettycash.SaveChangesAsync();
            return Ok(_dbContextPettycash);
        }*/
    }
}
