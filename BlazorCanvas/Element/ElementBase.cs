using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public class ElementBase:ComponentBase
    {
        /// <summary>
        /// 当前对象的区域范围
        /// </summary>
        [Parameter]
        public RectangleF Rect { get; set; }//不能用属性，因为属性不能给修改内部值

        
    }
}
