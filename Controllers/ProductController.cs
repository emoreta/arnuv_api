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
    public class ProductController : ControllerBase
    {
        private DbContextProduct _dbContextProduct;
        public ProductController(DbContextProduct context)
        {
            _dbContextProduct = context;
        }
        [HttpGet]
        [Route("getProduct/ ")]
        public ActionResult<List<Product>> Get()
        {
            return _dbContextProduct.Product.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Product> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Product id must be higher than zero");
            }
            Product ob = _dbContextProduct.Product.FirstOrDefault(s => s.idproduct == id);
            if (ob == null)
            {
                return NotFound(" Product not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            if (product == null)
            {
                return NotFound("product data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextProduct.Product.AddAsync(product);
            await _dbContextProduct.SaveChangesAsync();
            return Ok(product);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Product product)
        {
            if (product == null)
            {
                return NotFound("product data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Product ob = _dbContextProduct.Product.FirstOrDefault(s => s.idproduct == product.idproduct);
            if (ob == null)
            {
                return NotFound("Product does not exist in the database");
            }
            ob.codecurrency = product.codecurrency;
            ob.codeiva = product.codeiva;
            ob.codeproduct = product.codeproduct;
            ob.codestorage = product.codestorage;
            ob.discountpercentagea = product.discountpercentagea;
            ob.discountpercentageb = product.discountpercentageb;
            ob.discountpercentagec = product.discountpercentagec;
            ob.iceproduct = product.iceproduct;
            ob.idproduct = product.idproduct;
            ob.nameproduct = product.nameproduct;
            ob.observationproduct = product.observationproduct;
            ob.pricea = product.pricea;
            ob.priceb = product.priceb;
            ob.pricec = product.pricec;
            ob.stock = product.stock;
            _dbContextProduct.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextProduct.SaveChangesAsync();
            return Ok(_dbContextProduct);
        }
    }
}
