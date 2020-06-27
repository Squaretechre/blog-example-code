using System.Collections.Generic;
using Xunit;

namespace RefactoringIfStatements.LookupTables.Color.After.WithoutColorDescription
{
    public class ColorShould
    {
        [Theory]
        [InlineData("firebrick", "#B22222")]
        [InlineData("tomato", "#FF6347")]
        [InlineData("papayawhip", "#FFEFD5")]
        [InlineData("chartreuse", "#7FFF00")]
        [InlineData("honeydew", "#F0FFF0")]
        [InlineData("mintcream", "#F5FFFA")]
        public void have_correct_name_for_hex_value(string expectedName, string hex)
        {
            Assert.Equal(expectedName, new Color(hex).Name());
        }

        [Fact]
        public void return_empty_string_for_unknown_hex_value()
        {
            Assert.Equal(string.Empty, new Color("#000000").Name());
        }

        [Theory]
        [MemberData(nameof(HexToRgbTestData))]
        public void have_correct_rgb_values_for_hex_value(RgbValues expectedRgbValues, string hex)
        {
            Assert.Equal(expectedRgbValues, new Color(hex).Rgb());
        }

        [Fact]
        public void return_empty_rgb_values_for_unknown_hex_value()
        {
            Assert.Equal(RgbValues.Empty(), new Color("#000000").Rgb());
        }

        public static IEnumerable<object[]> HexToRgbTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new RgbValues(178, 34, 34),
                    "#B22222",
                },
                new object[]
                {
                    new RgbValues(255, 99, 71),
                    "#FF6347",
                },
                new object[]
                {
                    new RgbValues(255, 239, 213),
                    "#FFEFD5",
                },
                new object[]
                {
                    new RgbValues(127, 255, 0),
                    "#7FFF00",
                },
                new object[]
                {
                    new RgbValues(240, 255, 240),
                    "#F0FFF0",
                },
                new object[]
                {
                    new RgbValues(245, 255, 250),
                    "#F5FFFA",
                },
            };
    }
}
