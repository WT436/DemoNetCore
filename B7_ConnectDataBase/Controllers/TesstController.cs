using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace B7_ConnectDataBase.Controllers
{
    public class TesstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
