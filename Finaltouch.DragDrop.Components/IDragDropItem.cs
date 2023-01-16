using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Components
{
    public interface IDragDropItem
    {
        public string? Id { get; set; }
        public RenderFragment? Text { get; set; }
    }
}
