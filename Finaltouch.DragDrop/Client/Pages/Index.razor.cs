using Finaltouch.DragDrop.Client.Models;
using Finaltouch.DragDrop.Components;
using Finaltouch.DragDrop.Components.Utilities;
using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Client.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private DragDropInterop? DragDropInterop { get; set; }
        private Dictionary<string, DragDropList<ToDoItem>> Containers { get; set; } = new();
        private DragDropOptions DragDropOptions { get; set; } = new() { };
        private DragDropList<ToDoItem> Tasks { get; set; } = new() { };
        private DragDropList<ToDoItem> Priorities { get; set; } = new() { };
        private DragDropList<ToDoItem> Done { get; set; } = new() { };
        private StyleManager TasksStyle { get; set; } = new(backgroundColor: "#8bc34a");
        private StyleManager PrioritiesStyle { get; set; } = new(backgroundColor: "#e57373");
        private StyleManager DoneStyle { get; set; } = new(backgroundColor: "lightgray", textDecoration: "line-through");

        protected override Task OnInitializedAsync()
        {
            InitializeContainers();
            return base.OnInitializedAsync();
        }

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
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task OnRelease(DragDropResult result)
        {
            var sourceItem = Containers[result.SourceContainerId].FirstOrDefault(i => i.Id == result.SourceItemId);
            if (sourceItem != null)
            {
                if (string.IsNullOrEmpty(result.TargetItemId))
                {
                    Containers[result.SourceContainerId].Remove(sourceItem);
                    Containers[result.TargetContainerId].Add(sourceItem);
                }
                if (result.SourceItemId != result.TargetItemId)
                {
                    var targetItem = Containers[result.TargetContainerId].FirstOrDefault(i => i.Id == result.TargetItemId);
                    if (targetItem != null)
                    {
                        Containers[result.SourceContainerId].Remove(sourceItem);
                        var index = Containers[result.TargetContainerId].IndexOf(targetItem);
                        Containers[result.TargetContainerId].Insert(index, sourceItem);
                    }
                }
            }
            StateHasChanged();
            await Task.CompletedTask;
        }

        private void InitializeContainers()
        {
            // setup data here
            var tasks = new string[] { "Do the dishes", "Take out the trash", "Mow the lawn" };
            foreach (var task in tasks)
            {
                Tasks.Add(new ToDoItem { Text = GetTask(task) });
            }
            Containers.Add(Tasks.Id, Tasks);
            var priorities = new string[] { "Polish the dog", "Feed the boa constrictor" };
            foreach (var priority in priorities)
            {
                Priorities.Add(new ToDoItem { Text = GetTask(priority) });
            }
            Containers.Add(Priorities.Id, Priorities);
            Containers.Add(Done.Id, Done);
        }

        private RenderFragment GetTask(string task)
        {
            return builder =>
            {
                builder.OpenElement(0, "span");
                builder.AddContent(1, task);
                builder.CloseElement();
            };
        }

    }
}

