using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringIfStatements.LookupTables.Trivia.After
{
    public class Game
    {
        private const string CategoryPop = "Pop";
        private const string CategoryScience = "Science";
        private const string CategorySports = "Sports";
        private const string CategoryRock = "Rock";

        private readonly Dictionary<int, string> _categories = new Dictionary<int, string>
        {
            { 0, CategoryPop },
            { 4, CategoryPop },
            { 8, CategoryPop },
            { 1, CategoryScience },
            { 5, CategoryScience },
            { 9, CategoryScience },
            { 2, CategorySports },
            { 6, CategorySports },
            { 10, CategorySports },
            { 11, CategoryRock },
        };

        private readonly List<string> _players = new List<string>();

        private readonly LinkedList<string> _popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        private readonly int[] _places = new int[6];
        private readonly int _currentPlayer;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(CreateRockQuestion(i));
            }
        }

        public string CreateRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

        public bool Add(string playerName)
        {
            _players.Add(playerName);
            return true;
        }

        public void Roll(int roll)
        {
            _places[_currentPlayer] = _places[_currentPlayer] + roll;
            if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

            AskQuestion();
        }

        private void AskQuestion()
        {
            var placesAdvancedByCurrentPlayer = _places[_currentPlayer];

            if (CategoryFor(placesAdvancedByCurrentPlayer) == CategoryPop)
            {
                Console.WriteLine(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (CategoryFor(placesAdvancedByCurrentPlayer) == CategoryScience)
            {
                Console.WriteLine(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (CategoryFor(placesAdvancedByCurrentPlayer) == CategorySports)
            {
                Console.WriteLine(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (CategoryFor(placesAdvancedByCurrentPlayer) == CategoryRock)
            {
                Console.WriteLine(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }

        private string CategoryFor(int placesAdvancedByCurrentPlayer)
        {
            return _categories[placesAdvancedByCurrentPlayer];
        }
    }
}
