using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas.Element
{
    public partial class Output
    {
        public const int Height = 90;
        public const int Width = 250;

        [Parameter]
        public OutputData Data { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Rect = new Rect(0, 0, Width, Height);
        }

        public void addOutput()
        {
            Flow.Data.Output = new OutputData();
        }

        public void removeOutput()
        {
            Flow.Data.Output = null;
        }

    }
}
