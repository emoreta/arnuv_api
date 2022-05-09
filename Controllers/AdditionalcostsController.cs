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
    public class AdditionalcostsController : ControllerBase
    {
        private DbContextAdditionalcosts _dbContextAdditionalcosts;
        public AdditionalcostsController(DbContextAdditionalcosts context)
        {
            _dbContextAdditionalcosts = context;
        }
        [HttpGet]
        [Route("getAdditionalcosts/ ")]
        public ActionResult<IEnumerable<Additionalcosts>> Get()
        {
            return _dbContextAdditionalcosts.Additionalcosts.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Additionalcosts> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Additionalcosts id must be higher than zero");
            }
            Additionalcosts ob = _dbContextAdditionalcosts.Additionalcosts.FirstOrDefault(s => s.idadditionalcost == id);
            if (ob == null)
            {
                return NotFound(" Additionalcosts not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Additionalcosts additionalcosts)
        {
            if (additionalcosts == null)
            {
                return NotFound("additionalcosts data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextAdditionalcosts.Additionalcosts.AddAsync(additionalcosts);
            await _dbContextAdditionalcosts.SaveChangesAsync();
            return Ok(additionalcosts);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Additionalcosts additionalcosts)
        {
            if (additionalcosts == null)
            {
                return NotFound("additionalcosts data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Additionalcosts ob = _dbContextAdditionalcosts.Additionalcosts.FirstOrDefault(s => s.idadditionalcost == additionalcosts.idadditionalcost);
            if (ob == null)
            {
                return NotFound("Additionalcosts does not exist in the database");
            }
            ob.codeadditionalcost = additionalcosts.codeadditionalcost;
            ob.idadditionalcost = additionalcosts.idadditionalcost;
            ob.isavailableadditionalcosts = additionalcosts.isavailableadditionalcosts;
            ob.nameadditionalcosts = additionalcosts.nameadditionalcosts;
            ob.valueadditionalcost = additionalcosts.valueadditionalcost;
            _dbContextAdditionalcosts.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextAdditionalcosts.SaveChangesAsync();
            return Ok(_dbContextAdditionalcosts);
        }
    }
}
