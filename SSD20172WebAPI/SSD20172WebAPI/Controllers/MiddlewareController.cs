using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSD20172WebAPI.Models;

namespace SSD20172WebAPI.Controllers
{
    [Route("[controller]/request")]
    public class MiddlewareController : Controller
    {
        public static MiddlewareRequest CurrentRequest = new MiddlewareRequest { Status = "Finished" };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CurrentRequest);
        }

        [HttpPost]
        public IActionResult Post([FromBody]MiddlewareRequest request)
        {
            if (ModelState.IsValid)
            {
                CurrentRequest = request;

                return Ok(CurrentRequest);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}