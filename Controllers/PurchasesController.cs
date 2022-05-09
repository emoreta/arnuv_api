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
    public class PurchasesController : ControllerBase
    {
        private DbContextArnuv _dbContextPurchases;
        public PurchasesController(DbContextArnuv context)
        {
            _dbContextPurchases = context;
        }
        [HttpGet]
        [Route("getPurchases/")]
        public ActionResult<IEnumerable<Purchases>> Get()
        {

            IEnumerable<Purchases> query =
                       //from procesoDiario in _dbContextTcontdetalle.Tcontprocesodiario
                       from purchases in _dbContextPurchases.Purchases
                           /*join detalle in _dbContextTcontdetalle.Tcontdetalle on cabecera.idcabecera equals detalle.idcabecera
                           join estadoDetalle in _dbContextTcontdetalle.Tcontestado on detalle.idestado equals estadoDetalle.idestado
                           join homologacion in _dbContextTcontdetalle.Tconthomologacioncausal on detalle.codigorespuestaarchivodetalle equals homologacion.id*/
                       where purchases.isavailablepurchase == true
                       select new Purchases
                       {
                           codeprovider = purchases.codeprovider,
                           datecreatedpurchases = purchases.datecreatedpurchases,
                           datedocumentpurchases = purchases.datedocumentpurchases,
                           detailinvoicepurchases = purchases.detailinvoicepurchases,
                           detailseatpurchases = purchases.detailseatpurchases,
                           idpurchases = purchases.idpurchases,
                           idtypepayments = purchases.idtypepayments,
                           isavailablepurchase = purchases.isavailablepurchase,
                           ivainvoicepurchases = purchases.ivainvoicepurchases,
                           numberautorizationinvoicepurchases = purchases.numberautorizationinvoicepurchases,
                           numberinvoicepurchases = purchases.numberinvoicepurchases,
                           subtotalinvoicepurchases = purchases.subtotalinvoicepurchases,
                           totalpurchases = purchases.totalpurchases

                       };

            return query.OrderByDescending(x=>x.idpurchases).ToList();
            //return _dbContextPurchases.Purchases.ToList();
        }
        [HttpGet]
        [Route("getPurchasesBetweenDate/")]
        public ActionResult<IEnumerable<Purchases>> Get(DateTime fechaInicio, DateTime fechaFin)
        {

            IEnumerable<Purchases> query =
                       //from procesoDiario in _dbContextTcontdetalle.Tcontprocesodiario
                       from purchases in _dbContextPurchases.Purchases
                           /*join detalle in _dbContextTcontdetalle.Tcontdetalle on cabecera.idcabecera equals detalle.idcabecera
                           join estadoDetalle in _dbContextTcontdetalle.Tcontestado on detalle.idestado equals estadoDetalle.idestado
                           join homologacion in _dbContextTcontdetalle.Tconthomologacioncausal on detalle.codigorespuestaarchivodetalle equals homologacion.id*/
                       where purchases.isavailablepurchase == true &&
                       (purchases.datecreatedpurchases >= fechaInicio 
                       && purchases.datecreatedpurchases <= fechaFin)
                       select new Purchases
                       {
                           codeprovider = purchases.codeprovider,
                           datecreatedpurchases = purchases.datecreatedpurchases,
                           datedocumentpurchases = purchases.datedocumentpurchases,
                           detailinvoicepurchases = purchases.detailinvoicepurchases,
                           detailseatpurchases = purchases.detailseatpurchases,
                           idpurchases = purchases.idpurchases,
                           idtypepayments = purchases.idtypepayments,
                           isavailablepurchase = purchases.isavailablepurchase,
                           ivainvoicepurchases = purchases.ivainvoicepurchases,
                           numberautorizationinvoicepurchases = purchases.numberautorizationinvoicepurchases,
                           numberinvoicepurchases = purchases.numberinvoicepurchases,
                           subtotalinvoicepurchases = purchases.subtotalinvoicepurchases,
                           totalpurchases = purchases.totalpurchases

                       };

            return query.OrderByDescending(x => x.idpurchases).ToList();
            //return _dbContextPurchases.Purchases.ToList();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Purchases> Get(int id)
        {
            if (id == 0)
            {
                return NotFound("Purchases id must be higher than zero");
            }
            Purchases ob = _dbContextPurchases.Purchases.FirstOrDefault(s => s.idpurchases == id);
            if (ob == null)
            {
                return NotFound(" Purchases not found");
            }
            return Ok(ob);
        }
        [HttpPost]
        [Route("insert/")]
        public async Task<ActionResult> Post([FromBody] Purchases purchases)
        {
            if (purchases == null)
            {
                return NotFound("purchases data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbContextPurchases.Purchases.AddAsync(purchases);
            await _dbContextPurchases.SaveChangesAsync();
            return Ok(purchases);
        }
        [HttpPut]
        [Route("update/")]
        public async Task<ActionResult> Update([FromBody] Purchases purchases)
        {
            if (purchases == null)
            {
                return NotFound("purchases data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Purchases ob = _dbContextPurchases.Purchases.FirstOrDefault(s => s.idpurchases == purchases.idpurchases);
            if (ob == null)
            {
                return NotFound("Purchases does not exist in the database");
            }
            ob.codeprovider = purchases.codeprovider;
            ob.datecreatedpurchases = purchases.datecreatedpurchases;
            ob.datedocumentpurchases = purchases.datedocumentpurchases;
            ob.detailinvoicepurchases = purchases.detailinvoicepurchases;
            ob.detailseatpurchases = purchases.detailseatpurchases;
            ob.idpurchases = purchases.idpurchases;
            ob.idtypepayments = purchases.idtypepayments;
            ob.isavailablepurchase = purchases.isavailablepurchase;
            ob.ivainvoicepurchases = purchases.ivainvoicepurchases;
            ob.numberautorizationinvoicepurchases = purchases.numberautorizationinvoicepurchases;
            ob.numberinvoicepurchases = purchases.numberinvoicepurchases;
            ob.subtotalinvoicepurchases = purchases.subtotalinvoicepurchases;
            ob.totalpurchases = purchases.totalpurchases;
            _dbContextPurchases.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextPurchases.SaveChangesAsync();
            return Ok(ob);
        }

        [HttpPut]
        [Route("updateDeletePurchase/")]
        public async Task<ActionResult> updateDeletePurchase([FromBody] Purchases purchases)
        {
            if (purchases == null)
            {
                return NotFound("purchases data is not supplied");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Purchases ob = _dbContextPurchases.Purchases.FirstOrDefault(s => s.idpurchases == purchases.idpurchases);
            if (ob == null)
            {
                return NotFound("Purchases does not exist in the database");
            }
            /*ob.codeprovider = purchases.codeprovider;
            ob.datecreatedpurchases = purchases.datecreatedpurchases;
            ob.datedocumentpurchases = purchases.datedocumentpurchases;
            ob.detailinvoicepurchases = purchases.detailinvoicepurchases;
            ob.detailseatpurchases = purchases.detailseatpurchases;
            ob.idpurchases = purchases.idpurchases;
            ob.idtypepayments = purchases.idtypepayments;
            ob.ivainvoicepurchases = purchases.ivainvoicepurchases;
            ob.numberautorizationinvoicepurchases = purchases.numberautorizationinvoicepurchases;
            ob.numberinvoicepurchases = purchases.numberinvoicepurchases;
            ob.subtotalinvoicepurchases = purchases.subtotalinvoicepurchases;
            ob.totalpurchases = purchases.totalpurchases;*/
            ob.isavailablepurchase = purchases.isavailablepurchase;
            _dbContextPurchases.Entry(ob).Property(x => x.codeprovider).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.datecreatedpurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.datedocumentpurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.detailinvoicepurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.detailseatpurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.idtypepayments).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.ivainvoicepurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.numberautorizationinvoicepurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.numberinvoicepurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.subtotalinvoicepurchases).IsModified = true;
            _dbContextPurchases.Entry(ob).Property(x => x.totalpurchases).IsModified = true;

            _dbContextPurchases.Attach(ob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContextPurchases.SaveChangesAsync();
            return Ok(ob);
        }
    }
}
