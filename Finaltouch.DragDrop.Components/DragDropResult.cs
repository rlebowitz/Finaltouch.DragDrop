using System.Text;

namespace Finaltouch.DragDrop.Components
{
    public class DragDropResult
    {
        public string SourceItemId { get; set; } = string.Empty;
        public string SourceContainerId { get; set; } = string.Empty;
        public string TargetItemId { get; set; } = string.Empty;
        public string TargetContainerId { get; set; } = string.Empty;
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"SourceItemId: {SourceItemId} ");
            sb.Append($"SourceContainerId: {SourceContainerId} ");
            sb.Append($"TargetItemId: {TargetItemId} ");
            sb.Append($"TargetContainerId: {TargetContainerId} ");
            return sb.ToString();
        }
    }
}
