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
    public class AccountbankController : ControllerBase
    {
        private DbContextAccountbank _dbContextAccountbank;
        public AccountbankController(DbContextAccountbank context)
        {
            _dbContextAccountbank = context;
        }
        [HttpGet]
        [Route("getAccountbank/")]
        public ActionResult<List<Accountbank>> Get()
        {
            return _dbContextAccountbank.Accountbank.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Accountbank> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Accountbank id must be higher than zero");
            }
            Accountbank ob = _dbContextAccountbank.Accountbank.FirstOrDefault(s => s.idaccountbank == id);
            if (ob == null)
            {
                return NotFound(" AccountbankIva not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Accountbank accountbank)
        {
            if (accountbank == null)
            {
                return NotFound("accountbank data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextAccountbank.Accountbank.AddAsync(accountbank);
            await _dbContextAccountbank.SaveChangesAsync();
            return Ok(accountbank);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Accountbank accountbank)
        {
            if (accountbank == null)
            {
                return NotFound("accountbank data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Accountbank ob = _dbContextAccountbank.Accountbank.FirstOrDefault(s => s.idaccountbank == accountbank.idaccountbank);
            if (ob == null)
            {
                return NotFound("Accountbank does not exist in the database");
            }
            ob.ctaaccountbank = accountbank.ctaaccountbank;
            ob.idaccountbank = accountbank.idaccountbank;
            ob.lockedaccountbank = accountbank.lockedaccountbank;
            ob.nameaccountbank = accountbank.nameaccountbank;
            ob.numberaccountbank = accountbank.numberaccountbank;
            _dbContextAccountbank.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextAccountbank.SaveChangesAsync();
            return Ok(_dbContextAccountbank);
        }
    }
}
