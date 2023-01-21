using Finaltouch.DragDrop.Components;
using Finaltouch.DragDrop.Components.Utilities;
using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Shared
{
    public class TrooperItem : IDragDropItem
    {
        public string? Id { get; set; } = $"trooper-{IdGenerator.GetId(6)}";
        public RenderFragment? Text { get; set; }
    }
}
