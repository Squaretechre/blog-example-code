using System;
using System.IO;
using Xunit;

namespace RefactoringIfStatements.LookupTables.Trivia.After
{
    public class GameShould
    {
        private readonly Game _sut;
        private readonly StringWriter _consoleOutput;

        public GameShould()
        {
            _sut = new Game();
            _sut.Add("Chet");
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(8)]
        public void ask_a_pop_question_when_the_current_player_has_advanced_0_4_or_8_places(int roll)
        {
            _sut.Roll(roll);
            Assert.Equal("Pop Question 0\r\n", _consoleOutput.ToString());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        public void ask_a_science_question_when_the_current_player_has_advanced_1_5_or_9_places(int roll)
        {
            _sut.Roll(roll);
            Assert.Equal("Science Question 0\r\n", _consoleOutput.ToString());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(6)]
        [InlineData(10)]
        public void ask_a_sports_question_when_the_current_player_has_advanced_2_6_or_10_places(int roll)
        {
            _sut.Roll(roll);
            Assert.Equal("Sports Question 0\r\n", _consoleOutput.ToString());
        }

        [Fact]
        public void ask_a_rock_question_when_the_current_player_has_advanced_11_places()
        {
            _sut.Roll(11);
            Assert.Equal("Rock Question 0\r\n", _consoleOutput.ToString());
        }
    }
}
