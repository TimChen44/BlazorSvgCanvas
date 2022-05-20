
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
        public const int FlowSpace = 20;
        public const int Height = 80;
        public const int Width = 200;

        //上一个对象
        [Parameter]
        public Input? PreviousInput { get; set; }

        [Parameter]
        public InputData Data { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            LayoutRedraw();
        }

        public override void LayoutRedraw()
        {
            base.LayoutRedraw();
            this.Rect = new System.Drawing.RectangleF(new System.Drawing.PointF(this.Rect.X, PreviousInput?.MaxBottom() ?? 0 + FlowSpace), new System.Drawing.SizeF(Width, Height));
        }
    }
}
