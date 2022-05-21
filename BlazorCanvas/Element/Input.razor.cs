
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas.Element
{
    public partial class Input
    {

        public const int Height = 90;
        public const int Width = 250;


        [Parameter]
        public InputData Data { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Rect = new Rect(0, 0, Width, Height);
        }

        public void addInput()
        {
            Flow.Data.Input = new InputData();
        }

        public void addTrunk()
        {
            Flow.Data.Trunks.Insert(0, new TrunkData());
        }
    }
}
