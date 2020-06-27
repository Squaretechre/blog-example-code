using System.Collections.Generic;

namespace RefactoringIfStatements.LookupTables.Color.After.WithColorDescription.Dictionary
{
    public class ColorDescription
    {
        public string Hex { get; }
        public string Name { get; }
        public RgbValues Rgb { get; }

        private static readonly Dictionary<string, ColorDescription> Descriptions = new Dictionary<string, ColorDescription>
        {
            { "#B22222",  new ColorDescription("#B22222", "firebrick", new RgbValues(178, 34, 34)) },
            { "#FF6347",  new ColorDescription("#FF6347", "tomato", new RgbValues(255, 99, 71)) },
            { "#FFEFD5",  new ColorDescription("#FFEFD5", "papayawhip", new RgbValues(255, 239, 213)) },
            { "#7FFF00",  new ColorDescription("#7FFF00", "chartreuse", new RgbValues(127, 255, 0)) },
            { "#F0FFF0",  new ColorDescription("#F0FFF0", "honeydew", new RgbValues(240, 255, 240)) },
            { "#F5FFFA",  new ColorDescription("#F5FFFA", "mintcream", new RgbValues(245, 255, 250)) },
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
            return Descriptions.ContainsKey(hex)
                ? Descriptions[hex]
                : Empty;
        }
    }
}