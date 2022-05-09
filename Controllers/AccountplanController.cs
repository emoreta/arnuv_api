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
    public class AccountplanController : ControllerBase
    {
        private DbContextArnuv _dbContextArnuv;
        public AccountplanController(DbContextArnuv context)
        {
            _dbContextArnuv = context;
        }
        [HttpGet]
        [Route("getAccountplan/")]
        public ActionResult<List<Accountplan>> Get()
        {

            return _dbContextArnuv.Accountplan.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Accountplan> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Accountplan id must be higher than zero");
            }
            Accountplan ob = _dbContextArnuv.Accountplan.FirstOrDefault(s => s.idaccountplan == id);
            if (ob == null)
            {
                return NotFound(" Accountplan not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Accountplan accountplan)
        {
            if (accountplan == null)
            {
                return NotFound("accountplan data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextArnuv.Accountplan.AddAsync(accountplan);
            await _dbContextArnuv.SaveChangesAsync();
            return Ok(accountplan);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Accountplan accountplan)
        {
            if (accountplan == null)
            {
                return NotFound("accountplan data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Accountplan ob = _dbContextArnuv.Accountplan.FirstOrDefault(s => s.idaccountplan == accountplan.idaccountplan);
            if (ob == null)
            {
                return NotFound("Accountplan does not exist in the database");
            }
            ob.balanceaccountplan = accountplan.balanceaccountplan;
            ob.codeaccountplan = accountplan.codeaccountplan;
            ob.createdaccountplan = accountplan.createdaccountplan;
            ob.detailaccountplan = accountplan.detailaccountplan;
            ob.idaccountplan = accountplan.idaccountplan;
            ob.idchildrenaccountplan = accountplan.idchildrenaccountplan;
            ob.idparentaccountplan = accountplan.idparentaccountplan;
            ob.isavailableaccountplan = accountplan.isavailableaccountplan;
            ob.levelaccountplan = accountplan.levelaccountplan;
            _dbContextArnuv.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextArnuv.SaveChangesAsync();
            return Ok(ob);
        }
    }
}
