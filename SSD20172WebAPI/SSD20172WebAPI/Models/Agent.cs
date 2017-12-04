using System;
using System.Collections.Generic;

namespace SSD20172WebAPI.Models
{
    public partial class Agent
    {
        public int AgentId { get; set; }
        public int? SimulationId { get; set; }
        public bool IsExpert { get; set; }
        public decimal Utilization { get; set; }

        public Simulation Simulation { get; set; }
    }
}
