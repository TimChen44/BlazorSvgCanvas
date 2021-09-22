using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public partial class EditJoystick
    {
        [Parameter]
        [EditorRequired]
        public ElementBase Element { get; set; }

        [CascadingParameter]
        public BzCanvas BzCanvas { get; set; }

        public RectangleF ERect => Element.Rect;

        private double MaxWidth => ERect.Width / 3;
        private double MaxHeight => ERect.Height / 3;

        private double ZoomSize => Math.Ceiling(10 / BzCanvas.Viewer.Zoom);

        public double JoyWidth => ZoomSize > MaxWidth ? MaxWidth : ZoomSize;
        public double JoyHeight => ZoomSize > MaxHeight ? MaxHeight : ZoomSize;
    }
}
