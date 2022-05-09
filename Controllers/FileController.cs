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
    public class FileController : ControllerBase
    {
        private DbContextFile _dbContextFile;
        public FileController(DbContextFile context)
        {
            _dbContextFile = context;
        }
        [HttpGet]
        [Route("getFile/")]
        public ActionResult<IEnumerable<File>> Get()
        {
            return _dbContextFile.File.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<File> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("File id must be higher than zero");
            }
            File ob = _dbContextFile.File.FirstOrDefault(s => s.idfile == id);
            if (ob == null)
            {
                return NotFound(" File not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] File file)
        {
            if (file == null)
            {
                return NotFound("file data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextFile.File.AddAsync(file);
            await _dbContextFile.SaveChangesAsync();
            return Ok(file);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] File file)
        {
            if (file == null)
            {
                return NotFound("file data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            File ob = _dbContextFile.File.FirstOrDefault(s => s.idfile == file.idfile);
            if (ob == null)
            {
                return NotFound("File does not exist in the database");
            }
            ob.extensionfile = file.extensionfile;
            ob.idfile = file.idfile;
            ob.namefile = file.namefile;
            ob.pathfile = file.pathfile;
            _dbContextFile.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextFile.SaveChangesAsync();
            return Ok(_dbContextFile);
        }
    }
}
