using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas.Element
{
    public partial class Trunk
    {
        public const int Height = 80;
        public const int Width = 200;

        [Parameter]
        public TrunkData Data { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Rect = new Rect(0, 0, Width, Height);
        }

        public void addTrunk()
        {
            var index = Flow.Data.Trunks.IndexOf(Data);
            Flow.Data.Trunks.Insert(index, new TrunkData());
        }
        public void removeTrunk()
        {
            Flow.Data.Trunks.Remove(Data);
        }

    }
}
