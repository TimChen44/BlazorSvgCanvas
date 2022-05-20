using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas.Data
{
    public class DataFlow
    {
        public List<FlowData> Flows { get; set; } = new List<FlowData>();
    }

    public class FlowData
    {
        public InputData Input { get; set; }
        public List<TrunkData> Trunks { get; set; } = new List<TrunkData>();
        public OutputData Output { get; set; }
    }

    public class InputData
    {

    }

    public class TrunkData
    {
        public List<Import> Imports { get; set; } = new List<Import>();

        public List<Fork> Forks { get; set; } = new List<Fork>();
    }

    public class OutputData
    {

    }
}
