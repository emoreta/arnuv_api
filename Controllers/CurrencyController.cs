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
    public class CurrencyController : ControllerBase
    {
        private DbContextArnuv _dbContextCurrency;
        public CurrencyController(DbContextArnuv context)
        {
            _dbContextCurrency = context;
        }
        [HttpGet]
        [Route("getCurrency/")]
        public ActionResult<List<Currency>> Get()
        {
            return _dbContextCurrency.Currency.ToList();
        }
        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Currency> Get(string id)
        {
            if (id == "")
            {
                return NotFound("Currency id must be higher than zero");
            }
            Currency ob = _dbContextCurrency.Currency.FirstOrDefault(s => s.codecurrency == id);
            if (ob == null)
            {
                return NotFound(" Currency not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Currency currency)
        {
            if (currency == null)
            {
                return NotFound("currency data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextCurrency.Currency.AddAsync(currency);
            await _dbContextCurrency.SaveChangesAsync();
            return Ok(currency);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Currency currency)
        {
            if (currency == null)
            {
                return NotFound("currency data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Currency ob = _dbContextCurrency.Currency.FirstOrDefault(s => s.codecurrency == currency.codecurrency);
            if (ob == null)
            {
                return NotFound("Currency does not exist in the database");
            }
            ob.codecurrency = currency.codecurrency;
            ob.namecurrency = currency.namecurrency;
            ob.symbolcurrency = currency.symbolcurrency;
            _dbContextCurrency.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextCurrency.SaveChangesAsync();
            return Ok(_dbContextCurrency);
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<Currency>> DeleteCurrency(string id)
        {
            var currencyData= await _dbContextCurrency.Currency.FindAsync(id);
            if (currencyData == null)
            {
                return NotFound();
            }

            _dbContextCurrency.Currency.Remove(currencyData);
            await _dbContextCurrency.SaveChangesAsync();

            return currencyData;
        }

    }
}
