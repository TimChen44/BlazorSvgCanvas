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
        public string Title { get; set; } = CountHelp.getC();

        public InputData Input { get; set; }
        public List<TrunkData> Trunks { get; set; } = new List<TrunkData>();
        public OutputData Output { get; set; }
    }

    public class InputData
    {
        public string Title { get; set; } = CountHelp.getC();
    }

    public class TrunkData
    {
        public string Title { get; set; } = CountHelp.getC();

        public List<ImportData> Imports { get; set; } = new List<ImportData>();

        public List<ForkData> Forks { get; set; } = new List<ForkData>();
    }

    public class OutputData
    {
        public string Title { get; set; } = CountHelp.getC();

    }

    public class ImportData
    {
        public string Title { get; set; } = CountHelp.getC();
    }

    public class ForkData
    {
        public string Title { get; set; } = CountHelp.getC();
    }
}
