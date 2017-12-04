using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSD20172WebAPI.Models
{
    public class MiddlewareRequest
    {
        public string Status { get; set; }
        public bool IsAdvanced { get; set; }
        public int NumExpertAgents { get; set; }
        public int NumNewAgents { get; set; }
        public Simulation Simulation { get; set; }
    }
}
