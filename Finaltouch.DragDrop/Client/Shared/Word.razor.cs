using Microsoft.AspNetCore.Components;

namespace Finaltouch.DragDrop.Client.Shared
{
    //https://github.com/ChinmayMhatre/Unolingo/blob/master/components/Word.jsx
    public partial class Word
    {
        [Parameter]
        public string? Text { get; set; }
        [Parameter]
        public string? Hint { get; set; }
    }
}
