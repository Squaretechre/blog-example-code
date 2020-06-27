using System.Collections.Generic;
using System.Linq;

namespace RefactoringIfStatements.LookupTables.Color.After.WithColorDescription.List
{
    public class ColorDescription
    {
        public string Hex { get; }
        public string Name { get; }
        public RgbValues Rgb { get; }

        private static readonly List<ColorDescription> Descriptions = new List<ColorDescription>
        {
            new ColorDescription("#B22222", "firebrick", new RgbValues(178, 34, 34)),
            new ColorDescription("#FF6347", "tomato", new RgbValues(255, 99, 71)),
            new ColorDescription("#FFEFD5", "papayawhip", new RgbValues(255, 239, 213)),
            new ColorDescription("#7FFF00", "chartreuse", new RgbValues(127, 255, 0)),
            new ColorDescription("#F0FFF0", "honeydew", new RgbValues(240, 255, 240)),
            new ColorDescription("#F5FFFA", "mintcream", new RgbValues(245, 255, 250)),
        };

        private static readonly ColorDescription Empty = new ColorDescription(string.Empty, string.Empty, RgbValues.Empty());

        private ColorDescription(string hex, string name, RgbValues rgb)
        {
            Hex = hex;
            Name = name;
            Rgb = rgb;
        }

        public static ColorDescription ForHex(string hex)
        {
            return Descriptions.FirstOrDefault(x => x.Hex.Equals(hex)) ?? Empty;
        }

        public static ColorDescription ForName(string name)
        {
            return Descriptions.FirstOrDefault(x => x.Name.Equals(name)) ?? Empty;
        }
    }
}