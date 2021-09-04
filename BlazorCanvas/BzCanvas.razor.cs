using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public partial class BzCanvas
    {
        private Viewer Viewer { get; set; } 

        //TODO:将来需要支持百分比宽度
        [Parameter] public int Width { get; set; }
        [Parameter] public int Height { get; set; }

        public BzCanvas()
        {
            Viewer = new Viewer(this);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Viewer.Width = Width;
            Viewer.Height = Height;
        }



        public void OnMouseDown(MouseEventArgs e)
        {
            Viewer.MouseDown(e);
        }
        public void OnMouseUp(MouseEventArgs e)
        {
            Viewer.MouseUp(e);
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            Viewer.MouseMove(e);
        }

        public void OnWheel(WheelEventArgs e)
        {
            Viewer.MouseWheel(e);
        }

    }
}
