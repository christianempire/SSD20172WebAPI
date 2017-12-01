using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD20172WebAPI.Models
{
    public class SimpleSimulation
    {
        public int NumNewAgents { get; set; }
        public int NumExpertAgents { get; set; }
        public decimal AvgTimeInSystem { get; set; }
        public decimal AvgWaitingTime { get; set; }
        public List<SimpleSimulationAgent> Agents { get; set; }
        public decimal AvgNumberInQueue { get; set; }
        public decimal MaxNumberInQueue { get; set; }
    }

    public class SimpleSimulationAgent
    {
        public bool IsExpert { get; set; }
        public decimal Utilization { get; set; }
    }
}
