using System.Collections.Generic;

namespace RefactoringIfStatements.LookupTables.Color.After.WithoutColorDescription
{
    public class Color
    {
        private readonly string _hex;

        private readonly Dictionary<string, string> _names = new Dictionary<string, string>
        {
            { "#B22222",  "firebrick" },
            { "#FF6347",  "tomato" },
            { "#FFEFD5",  "papayawhip" },
            { "#7FFF00",  "chartreuse" },
            { "#F0FFF0",  "honeydew" },
            { "#F5FFFA",  "mintcream" },
        };

        private readonly Dictionary<string, RgbValues> _rgbValues = new Dictionary<string, RgbValues>
        {
            { "#B22222",  new RgbValues(178, 34, 34) },
            { "#FF6347",  new RgbValues(255, 99, 71) },
            { "#FFEFD5",  new RgbValues(255, 239, 213) },
            { "#7FFF00",  new RgbValues(127, 255, 0) },
            { "#F0FFF0",  new RgbValues(240, 255, 240) },
            { "#F5FFFA",  new RgbValues(245, 255, 250) },
        };

        public Color(string hex)
        {
            _hex = hex;
        }

        public string Name()
        {
            return _names.ContainsKey(_hex) 
                ? _names[_hex] 
                : string.Empty;
        }

        public RgbValues Rgb()
        {
            return _rgbValues.ContainsKey(_hex)
                ? _rgbValues[_hex]
                : RgbValues.Empty();
        }
    }
}