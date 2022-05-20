using BlazorCanvas.Element;
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
        public Viewer Viewer { get; set; }

        public SelectionBox SelectionBox { get; set; }

        public EditorControl Editor { get; set; }

        /// <summary>
        /// 控件宽度
        /// </summary>
        [Parameter] public string Width { get; set; }
        /// <summary>
        /// 控件高度
        /// </summary>
        [Parameter] public string Height { get; set; }


        //TODO:此处需要通过JS交互获得证实的Svg尺寸，应为宽度可以设置百分比，或者界面发生调整，目前假设不使用百分比
        private int _SvgWidth;
        public int SvgWidth
        {
            get
            {
                int.TryParse(Width, out int _SvgWidth);
                return _SvgWidth;
            }
            set => _SvgWidth = value;
        }

        private int _SvgHeight;
        public int SvgHeight
        {
            get
            {
                int.TryParse(Height, out int _SvgHeight);
                return _SvgHeight;
            }
            set => _SvgHeight = value;
        }


        public void AddComponents(ComponentBase component)
        {
            if (component is Viewer)
                Viewer = component as Viewer;
            else if (component is SelectionBox)
                SelectionBox = component as SelectionBox;
            else if (component is EditorControl)
                Editor = component as EditorControl;
            else if (component is ElementBase)
                Elements.Add(component as ElementBase);
            else if (component is Input)
                Inputs.Add(component as Input);
        }


        public void OnMouseDown(MouseEventArgs e)
        {
            Viewer.MouseDown(e);
            SelectionBox.MouseDown(e);
        }
        public void OnMouseUp(MouseEventArgs e)
        {
            Viewer.MouseUp(e);
            SelectionBox.MouseUp(e);
        }
        public void OnMouseMove(MouseEventArgs e)
        {
            Viewer.MouseMove(e);
            SelectionBox.MouseMove(e);
        }
        public void OnWheel(WheelEventArgs e)
        {
            Viewer.MouseWheel(e);
        }

        [Parameter]
        public RenderFragment Backgrounder { get; set; }

        [Parameter]
        public RenderFragment Element { get; set; }

        public List<ElementBase> Elements { get; set; } = new List<ElementBase>();


        #region 数据流

        public DataFlow DataFlow { get; set; }


        public List<Input> Inputs { get; set; } = new List<Input>();


        #endregion
    }
}
