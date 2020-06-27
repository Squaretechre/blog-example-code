namespace RefactoringIfStatements.LookupTables.Color.Before
{
    public class Color
    {
        private readonly string _hex;

        public Color(string hex)
        {
            _hex = hex;
        }

        public string Name()
        {
            if (_hex.Equals("#B22222")) return "firebrick";
            if (_hex.Equals("#FF6347")) return "tomato";
            if (_hex.Equals("#FFEFD5")) return "papayawhip";
            if (_hex.Equals("#7FFF00")) return "chartreuse";
            if (_hex.Equals("#F0FFF0")) return "honeydew";
            if (_hex.Equals("#F5FFFA")) return "mintcream";
            return string.Empty;
        }

        public RgbValues Rgb()
        {
            if (_hex.Equals("#B22222")) return new RgbValues(178, 34, 34);
            if (_hex.Equals("#FF6347")) return new RgbValues(255, 99, 71);
            if (_hex.Equals("#FFEFD5")) return new RgbValues(255, 239, 213);
            if (_hex.Equals("#7FFF00")) return new RgbValues(127, 255, 0);
            if (_hex.Equals("#F0FFF0")) return new RgbValues(240, 255, 240);
            if (_hex.Equals("#F5FFFA")) return new RgbValues(245, 255, 250);
            return RgbValues.Empty();
        }
    }
}