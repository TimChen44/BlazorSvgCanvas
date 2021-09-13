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
        public ElementBase Element { get; set; }

        [CascadingParameter]
        public BzCanvas BzCanvas { get; set; }


        public RectangleF ERect => Element.Rect;

        public double JoyWidth => Math.Ceiling(10/ BzCanvas.Viewer.Zoom);

        public double JoyHeight => Math.Ceiling(10 / BzCanvas.Viewer.Zoom);
    }
}
