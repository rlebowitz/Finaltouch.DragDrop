using Microsoft.JSInterop;
using System.Text.Json;

namespace Finaltouch.DragDrop.Components
{
    /// <summary>
    /// A scoped Dependency Injection service for use in Blazor components supporting drag and drop
    /// functionality.  
    /// </summary>
    public class DragDropInterop : IAsyncDisposable
    {
        private Lazy<Task<IJSObjectReference>> ModuleTask { get; }
        private DotNetObjectReference<DragDropInterop>? ObjRef { get; }
        private Func<DragDropResult, Task>? Func { get; set; }
        public DragDropInterop(IJSRuntime jsRuntime)
        {
            ModuleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Finaltouch.DragDrop.Components/dragDropInterop.js").AsTask());
            ObjRef = DotNetObjectReference.Create(this);
        }

        public async ValueTask Initialize(Func<DragDropResult, Task>? func, DragDropOptions options)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            Func = func;
            options ??= new DragDropOptions();
            JsonSerializerOptions SerializerOptions = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false,
            };
            var jsonString = JsonSerializer.Serialize(options, SerializerOptions);
            var value = await ModuleTask.Value;
            await value.InvokeVoidAsync("initialize", ObjRef, jsonString);
        }

        public async ValueTask AddListeners()
        {
            var value = await ModuleTask.Value;
            await value.InvokeVoidAsync("addListeners");
        }

        [JSInvokable]
        public async Task OnPointerUp(DragDropResult result)
        {
            if (Func != null)
            {
                await Func(result);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (ModuleTask != null && ModuleTask.IsValueCreated)
            {
                var module = await ModuleTask.Value;
                await module.DisposeAsync();
            }
        }
    }

}