using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSD20172WebAPI.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Arena API running! :)";
        }
    }
}