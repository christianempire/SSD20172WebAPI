using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSD20172WebAPI.Models;

namespace SSD20172WebAPI.Controllers
{
    public class RunController : Controller
    {
        [Route("[controller]")]
        [HttpGet]
        public IActionResult Index([FromQuery]int numNewAgents, [FromQuery]int numExpertAgents)
        {
            //string response = "";

            //try
            //{
            //    // Run the model executor
            //    System.Diagnostics.Process process = new System.Diagnostics.Process();
            //    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //    startInfo.FileName = @"C:\ModelExecutor\SSD20172ConsoleApp.exe";
            //    startInfo.Arguments = "";
            //    process.StartInfo = startInfo;
            //    process.EnableRaisingEvents = true;
            //    process.Start();
            //    process.WaitForExit();

            //    // Read the output file
            //    //response = System.IO.File.ReadAllText(@"C:\Simulation\AirportServiceModel.out");
            //}
            //catch (Exception e)
            //{
            //    response = e.ToString();
            //}

            if (numNewAgents > 0 && numExpertAgents > 0)
            {
                var agents = new List<SimpleSimulationAgent>();

                for (int i = 0; i < numNewAgents; i++)
                {
                    agents.Add(new SimpleSimulationAgent {
                        IsExpert = false,
                        Utilization = 1.999M
                    });
                }

                for (int i = 0; i < numExpertAgents; i++)
                {
                    agents.Add(new SimpleSimulationAgent
                    {
                        IsExpert = true,
                        Utilization = 1.999M
                    });
                }

                var simpleSimulation = new SimpleSimulation
                {
                    NumNewAgents = numNewAgents,
                    NumExpertAgents = numExpertAgents,
                    AvgTimeInSystem = 1.9999M,
                    AvgWaitingTime = 1.999M,
                    Agents = agents,
                    AvgNumberInQueue = 1.999M,
                    MaxNumberInQueue = 1.999M
                };

                return Ok(simpleSimulation);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}