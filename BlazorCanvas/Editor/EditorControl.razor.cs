using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas
{
    public partial class EditorControl
    {
        [CascadingParameter]
        public BzCanvas BzCanvas { get; set; }

        protected override void OnInitialized()
        {
            this.BzCanvas?.AddComponents(this);
            base.OnInitialized();
        }

        /// <summary>
        /// 选择的对象集合
        /// </summary>
        public List<ElementBase> SelectedElements = new List<ElementBase>();

        /// <summary>
        /// 当前对象
        /// </summary>
        public ElementBase CurrentElement = null;


        /// <summary>
        /// 添加选中的对象
        /// </summary>
        /// <param name="elements"></param>
        public void AddSelected(List<ElementBase> elements)
        {
            SelectedElements.AddRange(elements);
            elements.ForEach(x => x?.Selected());

            //SelectedObjElementsEvent?.Invoke(SelectedElements);

        }

    }
}
