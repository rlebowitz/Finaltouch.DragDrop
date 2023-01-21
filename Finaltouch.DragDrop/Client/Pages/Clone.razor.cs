using Finaltouch.DragDrop.Components;
using Finaltouch.DragDrop.Shared;
using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Client.Pages
{
    public partial class Clone : ComponentBase
    {
        [Inject]
        private DragDropInterop? DragDropInterop { get; set; }
        private DragDropOptions DragDropOptions { get; set; } = new() { Clone = true, Sort = false };
        private string SourceContainerId = "primeContainer";
        private string SourceItemId = "prime";
        private string TargetContainerId = "cloneContainer";
        private List<TrooperItem> Troopers = new();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (DragDropInterop != null)
                {
                    await DragDropInterop.Initialize(OnRelease, DragDropOptions);
                }
            }
            if (DragDropInterop != null)
            {
                await DragDropInterop.AddListeners();
            }
        }

        public async Task OnRelease(DragDropResult result)
        {
            if (TargetContainerId == result.TargetContainerId)
            {
                var item = new TrooperItem();
                item.Text = GetTrooper(item?.Id);
                if (item != null)
                {
                    Troopers.Add(item);
                }
            }
            StateHasChanged();
            await Task.CompletedTask;
        }

        private RenderFragment GetTrooper(string? id)
        {
            return builder =>
            {
                builder.OpenElement(0, "img");
                builder.AddAttribute(1, "src", "images/trooper.png");
                builder.AddAttribute(2, "class", "miniTrooper");
                builder.AddAttribute(3, "data-item-id", id);
                builder.AddAttribute(4, "style", "height:50px;width:auto");
                builder.CloseElement();
            };
        }
    }
}
