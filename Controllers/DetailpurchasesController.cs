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
    public class DetailpurchasesController : ControllerBase
    {
        private DbContextArnuv _dbContextDetailpurchases;
        public DetailpurchasesController(DbContextArnuv context)
        {
            _dbContextDetailpurchases = context;
        }
        [HttpGet]
        [Route("getDetailpurchases/")]
        public ActionResult<List<Detailpurchases>> Get()
        {
            return _dbContextDetailpurchases.Detailpurchases.OrderByDescending(x=>x.iddetailpurchases).ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Detailpurchases> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Detailpurchases id must be higher than zero");
            }
            Detailpurchases ob = _dbContextDetailpurchases.Detailpurchases.FirstOrDefault(s => s.iddetailpurchases == id);
            if (ob == null)
            {
                return NotFound(" Detailpurchases not found");
            }
            return Ok(ob);
        }
        [HttpGet]
        [Route("getbyIdPurchase/{id}")]
        public ActionResult<IEnumerable<Detailpurchases>> GetDetailPurchase(int id)
        {
            if (id == 0)
            {
                return NotFound("Detailpurchases id must be higher than zero");
            }
            
            IEnumerable < Detailpurchases> ob = _dbContextDetailpurchases.Detailpurchases.Where(s => s.idpurchases == id && s.isavailable==true);
            if (ob == null)
            {
                return NotFound(" Detailpurchases not found");
            }
            return Ok(ob);
        }
        /*[HttpGet]
        [Route("getbyIdPurchase/{id}")]
        public ActionResult<Detailpurchases> GetDetailPurchase(int id)
        {
            if (id == 0)
            {
                return NotFound("Detailpurchases id must be higher than zero");
            }
            Detailpurchases ob = _dbContextDetailpurchases.Detailpurchases.FirstOrDefault(s => s.idpurchases == id);
            if (ob == null)
            {
                return NotFound(" Detailpurchases not found");
            }
            return Ok(ob);
        }*/
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Detailpurchases detailpurchases)
        {
            if (detailpurchases == null)
            {
                return NotFound("detailpurchases data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextDetailpurchases.Detailpurchases.AddAsync(detailpurchases);
            await _dbContextDetailpurchases.SaveChangesAsync();
            return Ok(detailpurchases);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Detailpurchases detailpurchases)
        {
            if (detailpurchases == null)
            {
                return NotFound("detailpurchases data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Detailpurchases ob = _dbContextDetailpurchases.Detailpurchases.FirstOrDefault(s => s.iddetailpurchases == detailpurchases.iddetailpurchases);
            if (ob == null)
            {
                return NotFound("Detailpurchases does not exist in the database");
            }
            ob.datecreatedpurchases = detailpurchases.datecreatedpurchases;
            ob.dateupdateddetailpurchases = detailpurchases.dateupdateddetailpurchases;
            ob.descriptiondetailpuchases = detailpurchases.descriptiondetailpuchases;
            ob.idaccountplan = detailpurchases.idaccountplan;
            ob.iddetailpurchases = detailpurchases.iddetailpurchases;
            ob.idpurchases = detailpurchases.idpurchases;
            ob.isavailable = detailpurchases.isavailable;
            ob.quantitydetailpurchases = detailpurchases.quantitydetailpurchases;
            ob.valuetotaldetailpurchases = detailpurchases.valuetotaldetailpurchases;
            ob.valueunitarydetailpurchases = detailpurchases.valueunitarydetailpurchases;
            ob.ivadetailpurchases= detailpurchases.ivadetailpurchases;
            _dbContextDetailpurchases.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextDetailpurchases.SaveChangesAsync();
            return Ok(ob);
        }
        [HttpPut]
        [Route("updateDeleteDetail/")]
        public async Task<ActionResult> updateDeleteDetail([FromBody] Detailpurchases detailpurchases)
        {
            if (detailpurchases == null)
            {
                return NotFound("detailpurchases data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Detailpurchases ob = _dbContextDetailpurchases.Detailpurchases.FirstOrDefault(s => s.iddetailpurchases == detailpurchases.iddetailpurchases);
            if (ob == null)
            {
                return NotFound("Detailpurchases does not exist in the database");
            }
            ob.isavailable = detailpurchases.isavailable;
            /*ob.datecreatedpurchases = detailpurchases.datecreatedpurchases;
            ob.dateupdateddetailpurchases = detailpurchases.dateupdateddetailpurchases;
            ob.descriptiondetailpuchases = detailpurchases.descriptiondetailpuchases;
            ob.idaccountplan = detailpurchases.idaccountplan;
            ob.iddetailpurchases = detailpurchases.iddetailpurchases;
            ob.idpurchases = detailpurchases.idpurchases;
            
            ob.quantitydetailpurchases = detailpurchases.quantitydetailpurchases;
            ob.valuetotaldetailpurchases = detailpurchases.valuetotaldetailpurchases;
            ob.valueunitarydetailpurchases = detailpurchases.valueunitarydetailpurchases;*/
            _dbContextDetailpurchases.Entry(ob).Property(x => x.datecreatedpurchases).IsModified = true;
            _dbContextDetailpurchases.Entry(ob).Property(x => x.dateupdateddetailpurchases).IsModified = true;
            _dbContextDetailpurchases.Entry(ob).Property(x => x.descriptiondetailpuchases).IsModified = true;
            _dbContextDetailpurchases.Entry(ob).Property(x => x.idaccountplan).IsModified = true;
            _dbContextDetailpurchases.Entry(ob).Property(x => x.idpurchases).IsModified = true;
            _dbContextDetailpurchases.Entry(ob).Property(x => x.quantitydetailpurchases).IsModified = true;
            _dbContextDetailpurchases.Entry(ob).Property(x => x.valuetotaldetailpurchases).IsModified = true;
            _dbContextDetailpurchases.Entry(ob).Property(x => x.valueunitarydetailpurchases).IsModified = true;
            
            _dbContextDetailpurchases.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextDetailpurchases.SaveChangesAsync();
            return Ok(ob);
        }
    }
}
