using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSD20172WebAPI.Models;

namespace SSD20172WebAPI.Controllers
{
    [Route("[controller]")]
    public class SimulationsController : Controller
    {
        private readonly SimulationDbContext _simulationDbContext;

        public SimulationsController(SimulationDbContext simulationDbContext)
        {
            _simulationDbContext = simulationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_simulationDbContext.Simulation.ToList());
        }

        [HttpGet]
        [Route("{simulationId:int}")]
        public IActionResult Get(int simulationId)
        {
            return Ok(_simulationDbContext.Simulation.SingleOrDefault(c => c.SimulationId == simulationId));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Simulation simulation)
        {
            if (ModelState.IsValid)
            {
                if (simulation.Agent.Count > 1)
                {
                    foreach (Agent agent in simulation.Agent)
                    {
                        _simulationDbContext.Agent.Add(agent);
                    }

                    simulation.CreatedOn = DateTime.UtcNow;

                    _simulationDbContext.Simulation.Add(simulation);
                    _simulationDbContext.SaveChanges();

                    return Ok(simulation);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}