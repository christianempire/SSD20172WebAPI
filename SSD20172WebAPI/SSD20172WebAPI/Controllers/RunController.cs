using Microsoft.AspNetCore.Mvc;
using SSD20172WebAPI.Models;
using System;
using System.Threading.Tasks;

namespace SSD20172WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    public class RunController : Controller
    {
        private readonly SimulationDbContext _simulationDbContext;

        public RunController(SimulationDbContext simulationDbContext)
        {
            _simulationDbContext = simulationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Simple([FromQuery]int numExpertAgents, [FromQuery]int numNewAgents)
        {
            if (MiddlewareController.CurrentRequest.Status == "Finished")
            {
                if ((numExpertAgents > 0 || numNewAgents > 0) && (numExpertAgents + numNewAgents > 4))
                {
                    MiddlewareController.CurrentRequest = new MiddlewareRequest
                    {
                        Status = "Submitted",
                        IsAdvanced = false,
                        NumExpertAgents = numExpertAgents,
                        NumNewAgents = numNewAgents
                    };

                    int tickDuration = 1000;
                    int maxAwaitingTicks = 15;
                    int ticks = 0;

                    while (MiddlewareController.CurrentRequest.Status == "Submitted" && ticks < maxAwaitingTicks)
                    {
                        await Task.Delay(tickDuration);
                        ticks++;
                    }

                    if (MiddlewareController.CurrentRequest.Status == "InProgress")
                    {
                        ticks = 0;
                        while (MiddlewareController.CurrentRequest.Status == "InProgress" && ticks < maxAwaitingTicks)
                        {
                            await Task.Delay(tickDuration);
                            ticks++;
                        }
                    }

                    if (MiddlewareController.CurrentRequest.Status == "Finished")
                    {
                        return Ok(MiddlewareController.CurrentRequest.Simulation);
                    }
                    else
                    {
                        MiddlewareController.CurrentRequest = new MiddlewareRequest
                        {
                            Status = "Finished"
                        };
                        return Accepted();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Accepted();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Advanced(
            [FromQuery]int numNewAgents, 
            [FromQuery]int numExpertAgents,
            [FromQuery]decimal totalServiceDuration,
            [FromQuery]decimal agentLunchDuration,
            [FromQuery]int minAgentsDuringLunch,
            [FromQuery]decimal meanArrivalTime,
            [FromQuery]decimal lowerTransferTime,
            [FromQuery]decimal upperTransferTime,
            [FromQuery]decimal expertAgentMeanServiceDuration,
            [FromQuery]decimal newAgentMeanServiceDuration)
        {
            if (MiddlewareController.CurrentRequest.Status == "Finished")
            {
                bool validation1 = (numExpertAgents > 0 || numNewAgents > 0) 
                    && totalServiceDuration > 0 
                    && agentLunchDuration > 0 
                    && minAgentsDuringLunch > 0
                    && meanArrivalTime > 0
                    && lowerTransferTime > 0
                    && upperTransferTime > 0
                    && expertAgentMeanServiceDuration > 0
                    && newAgentMeanServiceDuration > 0;
                bool validation2 = numExpertAgents + numNewAgents > minAgentsDuringLunch;
                bool validation3 = upperTransferTime > lowerTransferTime;

                if (validation1 && validation2 & validation3)
                {
                    Simulation simulation = new Simulation
                    {
                        TotalServiceDuration = totalServiceDuration,
                        AgentLunchDuration = agentLunchDuration,
                        MinAgentsDuringLunch = minAgentsDuringLunch,
                        MeanArrivalTime = meanArrivalTime,
                        LowerTransferTime = lowerTransferTime,
                        UpperTransferTime = upperTransferTime,
                        ExpertAgentMeanServiceDuration = expertAgentMeanServiceDuration,
                        NewAgentMeanServiceDuration = newAgentMeanServiceDuration
                    };

                    MiddlewareController.CurrentRequest = new MiddlewareRequest
                    {
                        Status = "Submitted",
                        IsAdvanced = true,
                        NumExpertAgents = numExpertAgents,
                        NumNewAgents = numNewAgents,
                        Simulation = simulation
                    };

                    int tickDuration = 1000;
                    int maxAwaitingTicks = 15;
                    int ticks = 0;

                    while (MiddlewareController.CurrentRequest.Status == "Submitted" && ticks < maxAwaitingTicks)
                    {
                        await Task.Delay(tickDuration);
                        ticks++;
                    }

                    if (MiddlewareController.CurrentRequest.Status == "InProgress")
                    {
                        ticks = 0;
                        while (MiddlewareController.CurrentRequest.Status == "InProgress" && ticks < maxAwaitingTicks)
                        {
                            await Task.Delay(tickDuration);
                            ticks++;
                        }
                    }

                    if (MiddlewareController.CurrentRequest.Status == "Finished")
                    {
                        return Ok(MiddlewareController.CurrentRequest.Simulation);
                    }
                    else
                    {
                        MiddlewareController.CurrentRequest = new MiddlewareRequest
                        {
                            Status = "Finished"
                        };
                        return Accepted();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Accepted();
            }
        }
    }
}