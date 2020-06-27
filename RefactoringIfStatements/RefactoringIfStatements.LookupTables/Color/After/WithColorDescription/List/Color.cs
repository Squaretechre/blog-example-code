namespace RefactoringIfStatements.LookupTables.Color.After.WithColorDescription.List
{
    public class Color
    {
        private readonly ColorDescription _description;

        public Color(string hex)
        {
            _description = ColorDescription.ForHex(hex);
        }

        public string Name()
        {
            return _description.Name;
        }

        public RgbValues Rgb()
        {
            return _description.Rgb;
        }
    }
}