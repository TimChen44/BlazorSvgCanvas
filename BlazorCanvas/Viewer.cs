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
    public class Viewer : ComponentBase
    {
        [CascadingParameter]
        public BzCanvas BzCanvas { get; set; }

        protected override void OnInitialized()
        {
            this.BzCanvas?.AddComponents(this);
            BoxWidth = BzCanvas.SvgWidth;
            BoxHeight = BzCanvas.SvgHeight;
            base.OnInitialized();
        }


        /// <summary>
        /// 零点坐标（默认为画板中间）
        /// </summary>
        public double ZeroX = 0;
        public double ZeroY = 0;

        /// <summary>
        /// 视口的大小
        /// </summary>
        public double BoxWidth = 0;
        public double BoxHeight = 0;

        public string ViewBoxBind => $"{ZeroX} {ZeroY} {BoxWidth} {BoxHeight}";

        //缩放比例
        public double Zoom
        {
            get
            {
                return BoxWidth / BzCanvas.SvgWidth;
            }
        }

        //最小比例
        private float MinZoom = 0.2f;
        //最大比例
        private float MaxZoom = 5;


        //鼠标中键按下
        bool IsMouseMiddleDown = false;

        /// <summary>
        /// 移动前鼠标位置
        /// </summary>
        double OldMouseX;
        double OldMouseY;

        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) IsMouseMiddleDown = true;
            OldMouseX = e.OffsetX;
            OldMouseY = e.OffsetY;
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) IsMouseMiddleDown = false;
        }


        public void MouseMove(MouseEventArgs e)
        {
            if (IsMouseMiddleDown == true)
            {//鼠标中键移动图纸
                var newMouseX = e.OffsetX;
                var newMouseY = e.OffsetY;

                var x = newMouseX - OldMouseX;
                var y = newMouseY - OldMouseY;

                ZeroX -= x * Zoom;
                ZeroY -= y * Zoom;

                OldMouseX = newMouseX;
                OldMouseY = newMouseY;
            }

        }

        public void MouseWheel(WheelEventArgs e)
        {
            //鼠标滚轮滚动图纸
            //计算鼠标的坐标位置相对于画板的比例
            var tMouseX = e.OffsetX / BzCanvas.SvgWidth;
            var tMouseY = e.OffsetY / BzCanvas.SvgHeight;

            if (e.DeltaY > 0)
            {//缩小
                if (Zoom > (1 / MinZoom)) return;

                //计算缩放时宽高改变量
                var tWidth = BoxWidth * 0.2f;
                var tHeight = BoxHeight * 0.2f;

                //分别设置视口坐标和大小
                ZeroX -= tWidth * tMouseX;
                ZeroY -= tHeight * tMouseY;

                BoxWidth += tWidth;
                BoxHeight += tHeight;
            }
            else
            {//放大
                if (Zoom < (1 / MaxZoom)) return;

                //计算缩放时宽高改变量
                var tWidth = BoxWidth * 0.2f;
                var tHeight = BoxHeight * 0.2f;

                //分别设置视口坐标和大小
                ZeroX += tWidth * tMouseX;
                ZeroY += tHeight * tMouseY;

                BoxWidth -= tWidth;
                BoxHeight -= tHeight;
            }


        }

        /// <summary>
        /// 设置缩放
        /// </summary>
        /// <param name="zoom"></param>
        //public void SetZoom(float zoom)
        //{
        //    Zoom = zoom;
        //}
        public void SetZero(int x, int y)
        {
            ZeroX = x;
            ZeroY = y;
        }

    }

    public static class MouseButtons
    {
        public const long Left = 0;
        public const long Middle = 1;
        public const long Right = 2;
    }
}
