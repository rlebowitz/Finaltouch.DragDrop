using Microsoft.AspNetCore.Components;

using Finaltouch.DragDrop.Components.Utilities;
namespace Finaltouch.DragDrop.Components
{
    public partial class DragDropItem<TItem> : ComponentBase where TItem : IDragDropItem
    {
        [CascadingParameter]
        public DragDropOptions? DragDropOptions { get; set; }
        [Parameter]
        public TItem? Item { get; set; }
        [Parameter]
        public StyleManager? DragDropStyle { get; set; }
    }
}
