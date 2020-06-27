using System.Collections.Generic;
using System.Linq;

namespace RefactoringIfStatements.LookupTables.Color.After.RemoveOriginalColorClass
{
    public class Color
    {
        public string Hex { get; }
        public string Name { get; }
        public RgbValues Rgb { get; }

        private static readonly List<Color> Descriptions = new List<Color>
        {
            new Color("#B22222", "firebrick", new RgbValues(178, 34, 34)),
            new Color("#FF6347", "tomato", new RgbValues(255, 99, 71)),
            new Color("#FFEFD5", "papayawhip", new RgbValues(255, 239, 213)),
            new Color("#7FFF00", "chartreuse", new RgbValues(127, 255, 0)),
            new Color("#F0FFF0", "honeydew", new RgbValues(240, 255, 240)),
            new Color("#F5FFFA", "mintcream", new RgbValues(245, 255, 250)),
        };

        private static readonly Color Empty = new Color(string.Empty, string.Empty, RgbValues.Empty());

        private Color(string hex, string name, RgbValues rgb)
        {
            Hex = hex;
            Name = name;
            Rgb = rgb;
        }

        public static Color ForHex(string hex)
        {
            return Descriptions.FirstOrDefault(x => x.Hex.Equals(hex)) ?? Empty;
        }

        public static Color ForName(string name)
        {
            return Descriptions.FirstOrDefault(x => x.Name.Equals(name)) ?? Empty;
        }
    }
}