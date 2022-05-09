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
    public class StorageController : ControllerBase
    {
        private DbContextStorage _dbContextStorage;
        public StorageController(DbContextStorage context)
        {
            _dbContextStorage = context;
        }
        [HttpGet]
        [Route("getStorage/ ")]
        public ActionResult<IEnumerable<Storage>> Get()
        {
            return _dbContextStorage.Storage.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Storage> Get(string id)
        {
            if (id == "")
            {
                return NotFound("Storage id must be higher than zero");
            }
            Storage ob = _dbContextStorage.Storage.FirstOrDefault(s => s.codestorage == id);
            if (ob == null)
            {
                return NotFound(" Storage not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Storage storage)
        {
            if (storage == null)
            {
                return NotFound("storage data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextStorage.Storage.AddAsync(storage);
            await _dbContextStorage.SaveChangesAsync();
            return Ok(storage);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Storage storage)
        {
            if (storage == null)
            {
                return NotFound("storage data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Storage ob = _dbContextStorage.Storage.FirstOrDefault(s => s.codestorage == storage.codestorage);
            if (ob == null)
            {
                return NotFound("Storage does not exist in the database");
            }
            ob.codestorage = storage.codestorage;
            ob.isavailablestorage = storage.isavailablestorage;
            ob.namestorage = storage.namestorage;
            _dbContextStorage.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextStorage.SaveChangesAsync();
            return Ok(_dbContextStorage);
        }
    }
}
