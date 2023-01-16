using BlazorComponentUtilities;
using Finaltouch.DragDrop.Components.Utilities;
using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Components
{
    public partial class DragDropContainer<TItem> : ComponentBase where TItem : IDragDropItem
    {
        [CascadingParameter]
        public DragDropOptions? DragDropOptions { get; set; }
        [Parameter]
        public DragDropList<TItem>? List { get; set; }
        [Parameter]
        public RenderFragment<TItem>? ItemTemplate { get; set; }
        [Parameter]
        public string? Title { get; set; }
        [Parameter]
        public StyleManager? DragDropStyle { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? CapturedAttributes { get; set; }

        //https://stackoverflow.com/questions/70885840/blazor-attribute-splatting-issues-with-cssbuilder-package
        private string? ClassList =>
            new CssBuilder(DragDropOptions == null ? "dd-container" : DragDropOptions.ContainerClass)
            .AddClassFromAttributes(CapturedAttributes)
            .Build();

        private string? ContainerStyle => DragDropStyle != null ? DragDropStyle.Style : string.Empty;
    }
}
