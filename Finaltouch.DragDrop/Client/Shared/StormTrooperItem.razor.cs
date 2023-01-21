using Finaltouch.DragDrop.Components;
using Finaltouch.DragDrop.Components.Utilities;
using Finaltouch.DragDrop.Shared;
using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Client.Shared
{
    public partial class StormTrooperItem<TItem> : ComponentBase where TItem : IDragDropItem
    {
        [CascadingParameter]
        public DragDropOptions? DragDropOptions { get; set; }
        [Parameter]
        public TrooperItem? Item { get; set; }
        [Parameter]
        public StyleManager? DragDropStyle { get; set; }
    }
}
