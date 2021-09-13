using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public class ElementBase : ComponentBase
    {
        [CascadingParameter]
        public BzCanvas BzCanvas { get; set; }

        /// <summary>
        /// 当前对象的区域范围
        /// </summary>
        [Parameter]
        public RectangleF Rect { get; set; }//不能用属性，因为属性不能给修改内部值

        /// <summary>
        /// 选择的
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// 焦点
        /// </summary>
        public bool IsFocus { get; set; } = false;

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

    }
}
