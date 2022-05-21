﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas.Core
{
    public record Rect
    {
        public Rect() { }

        public Rect(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        //public Rect(Point point, Size size)
        //{
        //    Point = point;
        //    Size = size;
        //}

        //public Rect(Padding padding, Rect rect)
        //{
        //    Point = new Point(padding.L, padding.T);
        //    Size = new Size(rect.W - padding.L - padding.R, rect.H - padding.T - padding.B);
        //}


        #region 坐标

        ///// <summary>
        ///// 坐标点
        ///// </summary>
        //public Point Point { get; set; }

        ///// <summary>
        ///// 尺寸
        ///// </summary>
        //public Size Size { get; set; }

        /// <summary>
        /// 复制尺寸
        /// </summary>
        /// <returns></returns>
        public Rect Copy()
        {
            return new Rect(X, Y, W, H);
        }

        /// <summary>
        /// 获取或设置左边线
        /// 设置后右边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int X { get; set; } = 0;

        /// <summary>
        /// 获取或设置顶边线
        /// 设置后底边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int Y { get; set; } = 0;

        /// <summary>
        /// 获取或设置宽度
        /// </summary>
        public int W { get; set; } = 0;

        /// <summary>
        /// 获取或设置高度
        /// </summary>
        public int H { get; set; } = 0;

        #endregion

        #region 边线坐标点

        /// <summary>
        /// 获取或设置左边线，等同于X
        /// </summary>
        public int L
        {
            get { return X; }
            set { X = value; }
        }

        /// <summary>
        /// 获取或设置顶边线，等同于Y
        /// </summary>
        public int T
        {
            get { return Y; }
            set { Y = value; }
        }

        /// <summary>
        /// 获取或设置右边线
        /// 设置后左边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int R
        {
            get { return X + W; }
            set { X = value - W; }
        }


        /// <summary>
        /// 获取或设置底边线
        /// 设置后顶边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int B
        {
            get { return Y + H; }
            set { Y = value - H; }
        }

        /// <summary>
        /// 获取或设置左右中心
        /// 设置后左右边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int C
        {
            get { return X + W / 2; }
            set { X = value - W / 2; }
        }


        /// <summary>
        /// 获取或设置上下中心
        /// 设置后上下边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int M
        {
            get { return Y + H / 2; }
            set { Y = value - H / 2; }
        }

        #endregion

        #region 四周中间的点

        /// <summary>
        /// 左中的Y值
        /// </summary>
        public int LCY =>  Y + H / 2;

        /// <summary>
        /// 上中的X值
        /// </summary>
        public int TCX => X + W / 2;

        /// <summary>
        /// 右中的Y值
        /// </summary>
        public int RCY => Y + H / 2;

        /// <summary>
        /// 下中的X值
        /// </summary>
        public int BCX => X + W / 2;

        #endregion

        #region 四周坐标点
        //TODO:之后根据需要决定属性是否可以赋值

        /// <summary>
        /// 左上
        /// </summary>
        /// <returns></returns>
        public Point LT => new Point(X, Y);
        /// <summary>
        /// 左中
        /// </summary>
        /// <returns></returns>
        public Point LM => new Point(X, Y + H / 2);
        /// <summary>
        /// 左下
        /// </summary>
        /// <returns></returns>
        public Point LB => new Point(X, Y + H);

        /// <summary>
        /// 中上
        /// </summary>
        /// <returns></returns>
        public Point CT => new Point(X + W / 2, Y);
        /// <summary>
        /// 中中
        /// </summary>
        /// <returns></returns>
        public Point CM => new Point(X + W / 2, Y + H / 2);
        /// <summary>
        /// 中下
        /// </summary>
        /// <returns></returns>
        public Point CB => new Point(X + W / 2, Y + H);

        /// <summary>
        /// 右上
        /// </summary>
        /// <returns></returns>
        public Point RT => new Point(X + W, Y);
        /// <summary>
        /// 右中
        /// </summary>
        /// <returns></returns>
        public Point RM => new Point(X + W, Y + H / 2);
        /// <summary>
        /// 右下
        /// </summary>
        /// <returns></returns>
        public Point RB => new Point(X + W, Y + H);

        #endregion 

        #region 操作符重载

        ///// <summary>
        ///// 正向偏移坐标
        ///// </summary>
        //public static Rect operator +(Rect rect, Point point)
        //{
        //    return new Rect(rect.Point + point, rect.Size);
        //}

        ///// <summary>
        ///// 反向偏移坐标
        ///// </summary>
        //public static Rect operator -(Rect rect, Point point)
        //{
        //    return new Rect(rect.Point - point, rect.Size);
        //}

        ///// <summary>
        ///// 增加尺寸
        ///// </summary>
        //public static Rect operator +(Rect rect, Size size)
        //{
        //    return new Rect(rect.Point, rect.Size + size);
        //}

        ///// <summary>
        ///// 减少尺寸
        ///// </summary>
        //public static Rect operator -(Rect rect, Size size)
        //{
        //    return new Rect(rect.Point, rect.Size - size);
        //}

        #endregion 

        /// <summary>
        /// 输出矩形的svg文本
        /// </summary>
        /// <returns></returns>
        public string ToPoints()
        {
            return $"{LT.ToPoint()} {RT.ToPoint()} {RB.ToPoint()} {LB.ToPoint()}";
        }
    }

    public record Point
    {
        public Point()
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y轴坐标
        /// </summary>
        public int Y { get; set; }

        #region 操作符重载

        /// <summary>
        /// 坐标相加
        /// </summary>
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        /// <summary>
        /// 坐标相减
        /// </summary>
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        #endregion 



        public string ToPoint()
        {
            return $"{X},{Y}";
        }
    }

    public record Size
    {
        public Size()
        {

        }

        public Size(int w, int h)
        {
            W = w;
            H = h;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public int W { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int H { get; set; }


        #region 操作符重载

        /// <summary>
        /// 坐标相加
        /// </summary>
        public static Size operator +(Size z1, Size z2)
        {
            return new Size(z1.W + z2.W, z1.H + z2.H);
        }

        /// <summary>
        /// 坐标相减
        /// </summary>
        public static Size operator -(Size z1, Size z2)
        {
            return new Size(z1.W - z2.W, z1.H - z2.H);
        }

        #endregion 

    }
}
