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
        //public FlowData()
        //{
        //    DataFlow = dataFlow;
        //}
        public string Title { get; set; } = DateTime.Now.ToString("mm:ss");

        //public DataFlow DataFlow { get; set; }

        public InputData Input { get; set; }
        public List<TrunkData> Trunks { get; set; } = new List<TrunkData>();
        public OutputData Output { get; set; }
    }

    public class InputData
    {
        //public InputData(FlowData flow)
        //{
        //    Flow = flow;
        //}
        public string Title { get; set; } = DateTime.Now.ToString("mm:ss");

        //public FlowData Flow { get; set; }
    }

    public class TrunkData
    {
        //public TrunkData(FlowData flow)
        //{
        //    Flow = flow;
        //}
        public string Title { get; set; } = DateTime.Now.ToString("mm:ss");

        //public FlowData Flow { get; set; }

        public List<Import> Imports { get; set; } = new List<Import>();

        public List<Fork> Forks { get; set; } = new List<Fork>();
    }

    public class OutputData
    {
        //public OutputData(FlowData flow)
        //{
        //    Flow = flow;
        //}

        public string Title { get; set; } = DateTime.Now.ToString("mm:ss");

        //public FlowData Flow { get; set; }
    }
}
