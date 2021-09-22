using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
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

                var end = BzCanvas.Viewer.MousePointToLocal(e);

                var distance = MathF.Sqrt((float)((end.X - StartX) * (end.X - StartX) + (end.Y - StartY) * (end.Y - StartY)));


                if (distance < 15)
                {//开始和结束距离短，认为是鼠标点击选择
                    PointSelectOver(e);
                }
                else
                {
                    BoxSelectOver(e);
                }

            }
        }

        /// <summary>
        /// 选择单个对象
        /// </summary>
        private void PointSelectOver(MouseEventArgs e)
        {
            if (e.CtrlKey != true)
            {
                //撤销以前的选择
                BzCanvas.Editor.ClearSelected();
                BzCanvas.Editor.ClearFocus();
            }
            var point = BzCanvas.Viewer.MousePointToLocal(e);
            var elm = BzCanvas.Elements.AsParallel().FirstOrDefault(x => x.Rect.Contains(new PointF((float)point.X, (float)point.Y)));
            if (elm != null)
            {
                BzCanvas.Editor.AddSelected(elm);
                BzCanvas.Editor.SetFocus(elm);
            }

        }

        /// <summary>
        /// 选择被框选的对象
        /// </summary>
        private void BoxSelectOver(MouseEventArgs e)
        {

            if (e.CtrlKey != true)
            {
                //撤销以前的选择
                BzCanvas.Editor.ClearSelected();
                BzCanvas.Editor.ClearFocus();
            }

            RectangleF selectRect = new RectangleF((float)X, (float)Y, (float)Width, (float)Height);

            if (IsLeftToRight == true)
            {//全部选中才算选中
                BzCanvas.Editor.AddSelected(BzCanvas.Elements.AsParallel().Where(x => selectRect.Contains(x.Rect) == true).ToList());
            }
            else
            {//相交就认为已经选中
                BzCanvas.Editor.AddSelected(BzCanvas.Elements.AsParallel().Where(x => x.Rect.IntersectsWith(selectRect) == true).ToList());
            }

            if (BzCanvas.Editor.FocusElement == null)
            {
                BzCanvas.Editor.SetFocus();
            }


            //if (Control.ModifierKeys != Keys.Control)
            //{
            //    //撤销以前的选择
            //    Editor.ClearSelected();
            //}
            //foreach (var item in Canvas.Layers)
            //{
            //    if (item.IsActive == false) continue;

            //    if (IsLeftToRight == true)
            //    {//全部选中才算选中
            //        Editor.AddSelected(item.Elements.AsParallel().Where(x => Rect.Contains(x.Rect) == true).ToList());
            //    }
            //    else
            //    {//相交就认为已经选中
            //        Editor.AddSelected(item.Elements.AsParallel().Where(x => x.Rect.IntersectsWith(Rect) == true).ToList());
            //    }
            //}
            //Editor.SetCurrent(Editor.SelectedElements.FirstOrDefault());
        }

    }
}
