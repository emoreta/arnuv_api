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
    public class AccountpayController : ControllerBase
    {
        private DbContextAccountpay _dbContextAccountpay;
        public AccountpayController(DbContextAccountpay context)
        {
            _dbContextAccountpay = context;
        }
        [HttpGet]
        [Route("getAccountpay/")]
        public ActionResult<List<Accountpay>> Get()
        {
            return _dbContextAccountpay.Accountpay.ToList();
        }
    }
}
