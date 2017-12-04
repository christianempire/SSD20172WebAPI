using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSD20172WebAPI.Controllers
{
    [Route("[controller]")]
    public class SimulationController : Controller
    {
        [HttpPost]
        public IActionResult Get()
        {
            return View();
        }
    }
}