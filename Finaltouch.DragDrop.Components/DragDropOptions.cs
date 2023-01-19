namespace Finaltouch.DragDrop.Components
{
    public class DragDropOptions
    {
        public string ContainerClass { get; set; } = "dd-container";
        public string ItemClass { get; set; } = "dd-item";
        public string HandleClass { get; set; } = string.Empty;
        public bool Sort { get; set; } = true;
        public bool Clone { get; set; } = false;

    }
}
