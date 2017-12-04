using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD20172WebAPI.Models
{
    public class Simulation
    {
        public int SimulationId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsAdvanced { get; set; }
        public string Description { get; set; }
        public decimal TotalServiceDuration { get; set; }
        public decimal AgentLunchDuration { get; set; }
        public int MinAgentsDuringLunch { get; set; }
        public decimal MeanArrivalTime { get; set; }
        public decimal LowerTransferTime { get; set; }
        public decimal UpperTransferTime { get; set; }
        public decimal ExpertAgentMeanServiceDuration { get; set; }
        public decimal NewAgentMeanServiceDuration { get; set; }
        public decimal AvgTimeInSystem { get; set; }
        public decimal AvgWaitingTime { get; set; }
        public decimal AvgNumberInQueue { get; set; }
        public decimal MaxNumberInQueue { get; set; }
        public List<Agent> Agents { get; set; }
    }
}
