using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        [HttpGet("{amout}/{payment}")]
        public ActionResult<IDictionary<string, string>> Get(int amout, int payment)
        {
            var HackChange = new HackChange.HackChangeCode();
            var result = HackChange.Change(amout, payment);
            return result;
        }
    }
}