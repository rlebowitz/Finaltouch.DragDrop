using System.Drawing;
using System.Text.RegularExpressions;

namespace Finaltouch.DragDrop.Components.Utilities
{
    public static partial class ColorExtensions
    {
        private static readonly Regex Regex = HexRegex();
        /// <summary>
        /// Convert a color name string to a Color struct.
        /// </summary>
        /// <param name="colorName">The specified name of the color (e.g. blue, lightgrey)</param>
        /// <returns>A Color struct or the default Color value if the color's name is not recognized.</returns>
        public static Color NameToColor(string colorName)
        {
            var value = Color.FromName(colorName);
            return value.IsNamedColor ? value : default;
        }

        /// <summary>
        /// Convert a color hex string representation to its RGB int value
        /// </summary>
        /// <param name="hex">The specified hex string either with or without a # prefix.</param>
        /// <returns>A Color struct or the default Color value if the hex value is not recognized..</returns>
        public static Color HexStringToColor(string hex)
        {
            var match = Regex.Match(hex);
            if (match.Success)
            {
                var hexString = match.Groups[1].Value;
                var intValue = int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
                return Color.FromArgb(intValue);
            }
            return default;
        }

        /// <summary>
        /// Returns the hex string representation of the specified Color.
        /// </summary>
        /// <param name="color">The specified Color.</param>
        /// <returns>The Color's hex string representation.</returns>
        public static string ToHexString(this Color color)
        {
            return $"{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        /// <summary>
        /// Shades (darkens) the specified Color by the specified percentage. 
        /// </summary>
        /// <param name="color">The specified Color value.</param>
        /// <param name="percentage">The specified percentage by which to shade the color (default is 0.25, range 0-1)</param>
        /// <remarks>//https://stackoverflow.com/questions/6615002/given-an-rgb-value-how-do-i-create-a-tint-or-shade</remarks>
        /// <returns>The shaded Color as a hex string value.</returns>
        public static Color Shade(this Color color, double percentage = 0.25)
        {
            return Color.FromArgb(Round(color.R * percentage), Round(color.G * percentage), Round(color.B * percentage));
        }

        /// <summary>
        /// Tints (lightens) the specified Color by the specified percentage. 
        /// </summary>
        /// <param name="color">The specified Color.</param>
        /// <param name="percentage">The specified percentage by which to tint the Color (default is 0.25, range 0-1)</param>
        /// <remarks>//https://stackoverflow.com/questions/6615002/given-an-rgb-value-how-do-i-create-a-tint-or-shade</remarks>
        /// <returns>The tinted Color as a hex string value.</returns>
        public static Color Tint(this Color color, double percentage = 0.25)
        {
            return Color.FromArgb(Round(color.R + percentage * (255 - color.R)),
                Round(color.G + percentage * (255 - color.G)), Round(color.B + percentage * (255 - color.B)));
        }

        /// <summary>
        /// Converts double value to Integer.
        /// </summary>
        /// <param name="d">The specified double value.</param>
        /// <returns>The double value's nearest integer value.</returns>
        private static int Round(double d)
        {
            return d < 0 ? (int)(d - 0.5) : (int)(d + 0.5);
        }

        [GeneratedRegex("^#?([A-Fa-f\\d]{2}[A-Fa-f\\d]{2}[A-Fa-f\\d]{2})$", RegexOptions.Compiled)]
        private static partial Regex HexRegex();
    }
}
