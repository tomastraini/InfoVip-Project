using InfoVip.Models;
using InfoVip.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Web;

namespace InfoVip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptosController : ControllerBase
    {
        public ICryptoService srv;

        public CryptosController(ICryptoService srv)
        {
            this.srv = srv;
        }

        [HttpGet]
        public ActionResult<Currency> getPrices()
        {
            return Ok(srv.getPrices());
        }

    }
}
