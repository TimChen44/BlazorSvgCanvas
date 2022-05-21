using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas.Element
{
    public class FlowNode : ElementBase, IDisposable
    {
        [CascadingParameter]
        public Flow Flow { get; set; }

        protected override void OnInitialized()
        {
            Flow?.AddComponents(this);
            base.OnInitialized();
        }

        public override void Dispose()
        {
            this.Flow?.RemoveComponents(this);
            base.Dispose();
        }
    }
}
