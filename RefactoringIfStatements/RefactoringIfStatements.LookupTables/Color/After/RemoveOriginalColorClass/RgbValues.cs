using System;

namespace RefactoringIfStatements.LookupTables.Color.After.RemoveOriginalColorClass
{
    public class RgbValues
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public RgbValues(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public static RgbValues Empty()
        {
            return new RgbValues(-1, -1, -1);
        }

        protected bool Equals(RgbValues other)
        {
            return Red == other.Red && Green == other.Green && Blue == other.Blue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RgbValues) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Red, Green, Blue);
        }
    }
}