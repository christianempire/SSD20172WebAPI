using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD20172WebAPI.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        public int SimulationId { get; set; }
        public bool IsExpert { get; set; }
        public decimal Utilization { get; set; }
    }
}
