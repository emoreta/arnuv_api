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
    public class DetailaccountpayController : ControllerBase
    {
        private DbContextDetailaccountpay _dbContextDetailaccountpay;
        public DetailaccountpayController(DbContextDetailaccountpay context)
        {
            _dbContextDetailaccountpay = context;
        }
        [HttpGet]
        [Route("getDetailaccountpay/ ")]
        public ActionResult<IEnumerable<Detailaccountpay>> Get()
        {
            return _dbContextDetailaccountpay.Detailaccountpay.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Detailaccountpay> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Detailaccountpay id must be higher than zero");
            }
            Detailaccountpay ob = _dbContextDetailaccountpay.Detailaccountpay.FirstOrDefault(s => s.iddetailaccountpay == id);
            if (ob == null)
            {
                return NotFound(" Detailaccountpay not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Detailaccountpay detailaccountpay)
        {
            if (detailaccountpay == null)
            {
                return NotFound("detailaccountpay data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextDetailaccountpay.Detailaccountpay.AddAsync(detailaccountpay);
            await _dbContextDetailaccountpay.SaveChangesAsync();
            return Ok(detailaccountpay);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Detailaccountpay detailaccountpay)
        {
            if (detailaccountpay == null)
            {
                return NotFound("detailaccountpay data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Detailaccountpay ob = _dbContextDetailaccountpay.Detailaccountpay.FirstOrDefault(s => s.iddetailaccountpay == detailaccountpay.iddetailaccountpay);
            if (ob == null)
            {
                return NotFound("Detailaccountpay does not exist in the database");
            }
            ob.amountdetailaccountpay = detailaccountpay.amountdetailaccountpay;
            ob.codedetailaccounpay = detailaccountpay.codedetailaccounpay;
            ob.discountdetailaccountpay = detailaccountpay.discountdetailaccountpay;
            ob.idaccountpay = detailaccountpay.idaccountpay;
            ob.iddetailaccountpay = detailaccountpay.iddetailaccountpay;
            ob.namedetailaccountpay = detailaccountpay.namedetailaccountpay;
            ob.quanitydetailaccountpay = detailaccountpay.quanitydetailaccountpay;
            ob.totaldetailaccountpay = detailaccountpay.totaldetailaccountpay;
            _dbContextDetailaccountpay.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextDetailaccountpay.SaveChangesAsync();
            return Ok(_dbContextDetailaccountpay);
        }
    }
}
