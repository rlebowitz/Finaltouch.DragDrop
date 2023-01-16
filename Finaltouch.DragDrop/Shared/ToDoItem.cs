using Finaltouch.DragDrop.Components;
using Finaltouch.DragDrop.Components.Utilities;
using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Client.Models
{
    public class ToDoItem : IDragDropItem
    {
        public string? Id { get; set; } = $"item-{IdGenerator.GetId(6)}";
        public RenderFragment? Text { get; set; }
    }
}
