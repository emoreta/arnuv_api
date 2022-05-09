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
    public class ProviderController : ControllerBase
    {
        private DbContextArnuv _dbContextProvider;
        public ProviderController(DbContextArnuv context)
        {
            _dbContextProvider = context;
        }
        [HttpGet]
        [Route("getProvider/")]
        public ActionResult<List<Provider>> Get()
        {
            return _dbContextProvider.Provider.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Provider> Get(string id)
        {
            if (id == "")
            {
                return NotFound("Provider id must be higher than zero");
            }
            Provider ob = _dbContextProvider.Provider.FirstOrDefault(s => s.codeprovider == id);
            if (ob == null)
            {
                return NotFound(" Provider not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Provider provider)
        {
            if (provider == null)
            {
                return NotFound("provider data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextProvider.Provider.AddAsync(provider);
            await _dbContextProvider.SaveChangesAsync();
            return Ok(provider);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Provider provider)
        {
            if (provider == null)
            {
                return NotFound("provider data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Provider ob = _dbContextProvider.Provider.FirstOrDefault(s => s.codeprovider == provider.codeprovider);
            if (ob == null)
            {
                return NotFound("Provider does not exist in the database");
            }
            ob.addressprovider = provider.addressprovider;
            ob.codeiva = provider.codeiva;
            ob.codeprovider = provider.codeprovider;
            ob.codetypeprovider = provider.codetypeprovider;
            ob.commentprovider = provider.commentprovider;
            ob.ctaprovider = provider.ctaprovider;
            ob.currentbalance = provider.currentbalance;
            ob.deadlinesprovider = provider.deadlinesprovider;
            ob.discountprovider = provider.discountprovider;
            ob.emailprovider = provider.emailprovider;
            ob.identificationprovider = provider.identificationprovider;
            ob.nameprovider = provider.nameprovider;
            ob.telephoneoneprovider = provider.telephoneoneprovider;
            ob.telephonetwoprovider = provider.telephonetwoprovider;
            _dbContextProvider.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextProvider.SaveChangesAsync();
            return Ok(ob);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<Provider>> DeleteCurrency(string id)
        {
            var providerData = await _dbContextProvider.Provider.FindAsync(id);
            if (providerData == null)
            {
                return NotFound();
            }
            _dbContextProvider.Provider.Remove(providerData);
            await _dbContextProvider.SaveChangesAsync();
            return providerData;
        }
    }
}
