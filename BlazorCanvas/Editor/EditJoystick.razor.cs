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

        public RectangleF ERect => Element.Rect;

        public double JoyWidth => Math.Ceiling(Element.Rect.Width / 10);

        public double JoyHeight => Math.Ceiling(Element.Rect.Height / 10);
    }
}
