using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public abstract class ElementBase : ComponentBase
    {
        [CascadingParameter]
        public BzCanvas BzCanvas { get; set; }

        /// <summary>
        /// 当前对象的区域范围
        /// </summary>
        [Parameter]
        public RectangleF Rect { get; set; }//不能用属性，因为属性不能给修改内部值

        #region 对象的四个边界

        /// <summary>
        /// 最左侧的坐标
        /// </summary>
        public virtual float MinLeft() { return Rect.X; }

        /// <summary>
        /// 最顶部的坐标
        /// </summary>
        public virtual float MinTop() { return Rect.Y; }


        /// <summary>
        /// 最右侧的坐标
        /// </summary>
        public virtual float MaxRight() { return Rect.Right; }

        /// <summary>
        /// 最底下的坐标
        /// </summary>
        public virtual float MaxBottom() { return Rect.Bottom; }

        #endregion

        /// <summary>
        /// 选择的
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// 焦点
        /// </summary>
        public bool IsFocus { get; set; } = false;


        /// <summary>
        /// 清除对象选择
        /// </summary>
        public void UnSelected()
        {
            IsSelected = false;
            IsFocus = false;
            UnSelectedEvent();
        }
        protected virtual void UnSelectedEvent() { }

        /// <summary>
        /// 选择对象
        /// </summary>
        public void Selected()
        {
            IsSelected = true;
            SelectedEvent();
        }
        protected virtual void SelectedEvent() { }

        protected override void OnInitialized()
        {
            this.BzCanvas?.AddComponents(this);
            base.OnInitialized();
        }

        protected virtual void UnFocusEvent() { }

        public void Focus()
        {
            IsFocus = true;
            FocusEvent();
        }
        protected virtual void FocusEvent() { }

        public void UnFocus()
        {
            IsFocus = false;
            UnFocusEvent();
        }

        /// <summary>
        /// 布局重绘
        /// </summary>
        public virtual void LayoutRedraw()
        {

        }

    }
}
