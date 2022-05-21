using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCanvas.Element
{
    public partial class Import
    {
        public const int Height = 40;
        public const int Width = 150;

        [Parameter]
        public ImportData Data { get; set; }

        [CascadingParameter]
        public Trunk Trunk { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.Rect = new Rect(0, 0, Width, Height);
        }

        public void removeImport()
        {
            Trunk.Data.Imports.Remove(Data);
        }

    }
}
