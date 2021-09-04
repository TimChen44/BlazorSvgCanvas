using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public class Viewer
    {

        private readonly BzCanvas BzCanvas;

        public Viewer(BzCanvas bzCanvas)
        {
            BzCanvas = bzCanvas;
        }

        /// <summary>
        /// 零点坐标（默认为画板中间）
        /// </summary>
        public double ZeroX = 0;
        public double ZeroY = 0;

        public double Width = 0;
        public double Height = 0;

        public string ViewBoxBind => $"{ZeroX} {ZeroY} {Width * Zoom} {Height * Zoom}";

        //缩放比例
        public float Zoom = 1;

        //最小比例
        private float MinZoom = 0.01f;
        //最大比例
        private float MaxZoom = 100;


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
            OldMouseX = e.ClientX;
            OldMouseY = e.ClientY;
        }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle) IsMouseMiddleDown = false;
        }


        public void MouseMove(MouseEventArgs e)
        {
            if (IsMouseMiddleDown == true)
            {//鼠标中键移动图纸
                var newMouseX = e.ClientX;
                var newMouseY = e.ClientY;

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
            double  tZeroX = 0;
            double tZeroY = 0;
            if (e.DeltaY > 0)
            {
                if (Zoom == MaxZoom) return;

                Zoom = Zoom * 1.25f;
                if (Zoom > MaxZoom) Zoom = MaxZoom;

                //tZeroX = (e.ClientX - ZeroX) - (e.ClientX - ZeroX) * 1.25f;
                //tZeroY = (e.ClientY - ZeroY) - (e.ClientY - ZeroY) * 1.25f;

            }
            else
            {

                if (Zoom == MinZoom) return;

                Zoom = Zoom * 0.8f;
                if (Zoom < MinZoom) Zoom = MinZoom;

                //tZeroX = (e.ClientX - ZeroX) - (e.ClientX - ZeroX) * 0.8f;
                //tZeroY = (e.ClientY - ZeroY) - (e.ClientY - ZeroY) * 0.8f;
            }


        }

        /// <summary>
        /// 设置缩放
        /// </summary>
        /// <param name="zoom"></param>
        public void SetZoom(float zoom)
        {
            Zoom = zoom;
        }
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
