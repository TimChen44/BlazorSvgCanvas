using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public partial class SelectionBox : ComponentBase
    {
        [CascadingParameter]
        public BzCanvas BzCanvas { get; set; }

        protected override void OnInitialized()
        {
            this.BzCanvas?.AddComponents(this);
            base.OnInitialized();
        }

        /// <summary>
        /// 是否从左往右选择
        /// </summary>
        public bool IsLeftToRight { get; set; } = true;

        public bool SelectionBoxIsShow { get; set; } = false;

        //鼠标左键按下
        bool IsMouseLeftDown = false;

        //框选开始位置
        public double StartX { get; set; }
        public double StartY { get; set; }

        //框选尺寸
        public double EndX { get; set; }
        public double EndY { get; set; }


        private double X => StartX < EndX ? StartX : EndX;
        private double Y => StartY < EndY ? StartY : EndY;
        private double Width => EndX - StartX < 0 ? StartX - EndX : EndX - StartX;

        private double Height => EndY - StartY < 0 ? StartY - EndY : EndY - StartY;

        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseLeftDown = true;
                var start = BzCanvas.Viewer.MousePointToLocal(e);
                StartX = start.X;
                StartY = start.Y;
                EndX = start.X;
                EndY = start.Y;
                SelectionBoxIsShow = true;
            }
        }

        public void MouseMove(MouseEventArgs e)
        {
            //比例缩放后结束坐标也要做调整
            if (IsMouseLeftDown == true)
            {
                var end = BzCanvas.Viewer.MousePointToLocal(e);

                IsLeftToRight = StartX < end.X;

                //StartX = StartX < end.X ? StartX : end.X;
                //StartY = StartY < end.Y ? StartY : end.Y;

                //var w = StartX - end.X;
                //var h = StartY - end.Y;

                //Width = w < 0 ? -w : w;
                //Height = h < 0 ? -h : h;

                EndX = end.X;
                EndY = end.Y;
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseLeftDown = false;
                SelectionBoxIsShow = false;

                //var end = Viewer.MousePointToLocal(e.Location);
                //if (end.Distance(Start) < 15)
                //{//开始和结束距离短，认为是鼠标点击选择
                //    PointSelectOver(e.Location);
                //}
                //else
                //{
                //    BoxSelectOver();
                //}

            }
        }
    }
}
