using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSD20172WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            var simulations = _simulationDbContext.Simulation.Include(s => s.Agent).ToList();

            if (simulations != null)
            {
                foreach (var simulation in simulations)
                {
                    foreach (var agent in simulation.Agent)
                    {
                        agent.Simulation = null;
                    }
                }

                return Ok(simulations);
            }
            else
            {
                return NotFound();
            }
                        
        }

        [HttpGet]
        [Route("{simulationId:int}")]
        public IActionResult Get(int simulationId)
        {
            Simulation simulation = _simulationDbContext.Simulation.Include(s => s.Agent).SingleOrDefault(c => c.SimulationId == simulationId);

            if (simulation != null)
            {
                foreach (var agent in simulation.Agent)
                {
                    agent.Simulation = null;
                }

                return Ok(simulation);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Simulation simulation)
        {
            if (ModelState.IsValid)
            {
                if (simulation.Agent.Count > 1)
                {
                    simulation.CreatedOn = DateTime.UtcNow;

                    _simulationDbContext.Simulation.Add(simulation);
                    _simulationDbContext.SaveChanges();

                    foreach (var agent in simulation.Agent)
                    {
                        agent.Simulation = null;
                    }

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

        [HttpDelete]
        [Route("{simulationId:int}")]
        public IActionResult Delete(int simulationId)
        {
            Simulation simulation = _simulationDbContext.Simulation.Include(s => s.Agent).SingleOrDefault(c => c.SimulationId == simulationId);

            if (simulation != null)
            {
                foreach (var agent in simulation.Agent)
                {
                    _simulationDbContext.Agent.Remove(agent);
                }
                _simulationDbContext.Simulation.Remove(simulation);
                _simulationDbContext.SaveChanges();
                return Ok(simulation);
            }
            else
            {
                return NotFound();
            }
        }
    }
}