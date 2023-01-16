using System.Drawing;
using System.Text;

namespace Finaltouch.DragDrop.Components.Utilities
{
    /// <summary>
    /// Style Holder class for the DragDrop container and items.
    /// </summary>
    /// <remarks>
    /// The default values are stored in the DragDropContainer.razor.css file
    /// </remarks>
    /// 
    public class StyleManager
    {
        public StyleManager(string color = "", string backgroundColor = "", string borderColor = "", string textDecoration = "")
        {
            ForeColor = string.IsNullOrWhiteSpace(color)
                ? default
                : color.StartsWith('#') ? ColorExtensions.HexStringToColor(color) : ColorExtensions.NameToColor(color);
            BackgroundColor = string.IsNullOrWhiteSpace(backgroundColor)
                ? default
                : backgroundColor.StartsWith('#') ? ColorExtensions.HexStringToColor(backgroundColor) : ColorExtensions.NameToColor(backgroundColor);
            BorderColor = string.IsNullOrWhiteSpace(borderColor)
                ? default
                : borderColor.StartsWith('#') ? ColorExtensions.HexStringToColor(borderColor) : ColorExtensions.NameToColor(borderColor);
            TextDecoration = textDecoration;
        }

        public Color ForeColor { get; set; }
        public Color BackgroundColor { get; set; }
        public string TextDecoration { get; set; }
        public Color BorderColor { get; set; }

        /// <summary>
        /// Returns a CSS style string for any non-default properties.
        /// </summary>
        public string Style
        {
            get
            {
                var sb = new StringBuilder();
                if (ForeColor != default)
                {
                    sb.Append($"--color: #{ForeColor.ToHexString()};");
                }
                if (BackgroundColor != default)
                {
                    sb.Append($"--bg-color: #{BackgroundColor.ToHexString()};");
                }
                if (!string.IsNullOrEmpty(TextDecoration))
                {
                    sb.Append($"--text-decoration: {TextDecoration};");
                }
                if (BorderColor != default)
                {
                    sb.Append($"--border-color: #{BorderColor.ToHexString()};");
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Creates a DragDropStyle with a lighter background color than the existing background color.
        /// </summary>
        public StyleManager TintStyle
        {
            get
            {
                return new StyleManager
                {
                    BackgroundColor = BackgroundColor.Tint(),
                    ForeColor = ForeColor,
                    BorderColor = BorderColor,
                    TextDecoration = TextDecoration
                };
            }
        }

        /// <summary>
        /// Creates a DragDropStyle with a darker background color than the existing background color.
        /// </summary>
        public StyleManager ShadeStyle
        {
            get
            {
                return new StyleManager
                {
                    BackgroundColor = BackgroundColor.Shade(),
                    ForeColor = ForeColor,
                    BorderColor = BorderColor,
                    TextDecoration = TextDecoration
                };
            }
        }

    }
}
