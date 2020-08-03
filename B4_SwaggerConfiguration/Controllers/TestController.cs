using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B4_SwaggerConfiguration.Controllers
{

    public class TestController : Controller
    {
        [HttpGet("/api/nam")]
        public IActionResult get()
        {
            return Ok(new { name = "Nam" });
        }
    }
}
