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
    public class CredittypeController : ControllerBase
    {
        private DbContextCredittype _dbContextCredittype;
        public CredittypeController(DbContextCredittype context)
        {
            _dbContextCredittype = context;
        }
        [HttpGet]
        [Route("getCredittype/ ")]
        public ActionResult<IEnumerable<Credittype>> Get()
        {
            return _dbContextCredittype.Credittype.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Credittype> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Credittype id must be higher than zero");
            }
            Credittype ob = _dbContextCredittype.Credittype.FirstOrDefault(s => s.idcredittype == id);
            if (ob == null)
            {
                return NotFound(" Credittype not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Credittype credittype)
        {
            if (credittype == null)
            {
                return NotFound("credittype data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextCredittype.Credittype.AddAsync(credittype);
            await _dbContextCredittype.SaveChangesAsync();
            return Ok(credittype);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Credittype credittype)
        {
            if (credittype == null)
            {
                return NotFound("credittype data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Credittype ob = _dbContextCredittype.Credittype.FirstOrDefault(s => s.idcredittype == credittype.idcredittype);
            if (ob == null)
            {
                return NotFound("Credittype does not exist in the database");
            }
            ob.codecredittype = credittype.codecredittype;
            ob.credittype = credittype.credittype;
            ob.idcredittype = credittype.idcredittype;
            ob.isavailablecredittype = credittype.isavailablecredittype;
            _dbContextCredittype.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextCredittype.SaveChangesAsync();
            return Ok(_dbContextCredittype);
        }
    }
}
