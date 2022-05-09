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
    public class TypepaymentsController : ControllerBase
    {
        private DbContextArnuv _dbContextTypepayments;
        public TypepaymentsController(DbContextArnuv context)
        {
            _dbContextTypepayments = context;
        }
        [HttpGet]
        [Route("getTypepayments/")]
        public ActionResult<List<Typepayments>> Get()
        {
            return _dbContextTypepayments.Typepayments.Where(s=>s.isavailabletypepayments==true).ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Typepayments> Get(String id)
        {
            if (id == "")
            {
                return NotFound("Typepayments id must be higher than zero");
            }
            Typepayments ob = _dbContextTypepayments.Typepayments.FirstOrDefault(s => s.idtypepayments == id);
            if (ob == null)
            {
                return NotFound(" Typepayments not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Typepayments typepayments)
        {
            if (typepayments == null)
            {
                return NotFound("typepayments data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextTypepayments.Typepayments.AddAsync(typepayments);
            await _dbContextTypepayments.SaveChangesAsync();
            return Ok(typepayments);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Typepayments typepayments)
        {
            if (typepayments == null)
            {
                return NotFound("typepayments data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Typepayments ob = _dbContextTypepayments.Typepayments.FirstOrDefault(s => s.idtypepayments == typepayments.idtypepayments);
            if (ob == null)
            {
                return NotFound("Typepayments does not exist in the database");
            }
            ob.descriptiontypepayments = typepayments.descriptiontypepayments;
            ob.idtypepayments = typepayments.idtypepayments;
            ob.isavailabletypepayments = typepayments.isavailabletypepayments;
            _dbContextTypepayments.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextTypepayments.SaveChangesAsync();
            return Ok(ob);
        }
    }
}
