using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace BlazorCanvas.Element
{
    public partial class Flow
    {
        public const int FlowSpace = 20;

        [Parameter]
        public FlowData Data { get; set; }

        //上一个对象
        [Parameter]
        public Flow? PreviousFlow { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Rect = new Rect(0, 0, 0, 0);
        }

        public override float MaxBottom()
        {
            return 100;
        }

        private List<ElementBase> Elements = new List<ElementBase>();

        public void AddComponents(ComponentBase component)
        {
            if (component is ElementBase elem)
                Elements.Add(elem);
        }

        public void RemoveComponents(ComponentBase component)
        {
            if (component is ElementBase elem && Elements.Contains(elem))
                Elements.Remove(elem);
        }


    }
}
