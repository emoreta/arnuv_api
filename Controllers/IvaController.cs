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
    public class IvaController : ControllerBase
    {
        private DbContextIva _dbContextIva;
        public IvaController(DbContextIva context)
        {
            _dbContextIva = context;
        }

        [HttpGet]
        [Route("getIva/")]
        public ActionResult<IEnumerable<Iva>> Get()
        {
            return _dbContextIva.Iva.Where(s=>s.isavailableIva==true).ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Iva> GetById(string id)
        {
            if (id != "")
            {
                return NotFound("Iva id must be higher than zero");
            }
            Iva iv = _dbContextIva.Iva.FirstOrDefault(s => s.codeIva == id);
            if (iv == null)
            {
                return NotFound("Iva not found");
            }
            return Ok(iv);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Iva iva)
        {
            if (iva == null)
            {
                return NotFound("Persona data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextIva.Iva.AddAsync(iva);
            await _dbContextIva.SaveChangesAsync();
            return Ok(iva);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Iva iva)
        {
            if (iva == null)
            {
                return NotFound("Stduent data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Iva existingIva = _dbContextIva.Iva.FirstOrDefault(s => s.codeIva == iva.codeIva);
            if (existingIva == null)
            {
                return NotFound("User does not exist in the database");
            }
            //existingIva.codeIva = iva.codeIva;
            existingIva.percentageIva = iva.percentageIva;
            existingIva.isavailableIva = iva.isavailableIva;
            _dbContextIva.Attach(existingIva).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextIva.SaveChangesAsync();
            return Ok(existingIva);
        }
    }
}
