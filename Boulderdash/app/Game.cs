using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Boulderdash.app.controller;
using Boulderdash.app.models;
using Boulderdash.app.views;

namespace Boulderdash
{
    public class Game
    {
        private LinkedList<Level> _levels;
        private LinkedListNode<Level> _selectedLevel;
        private InputView _inputView = new InputView();
        private OutputView _outputView = new OutputView();

        //Start the game
        public Game()
        {
            //Parse all the levels
            _levels = new Parser().Levels;

            //Select the first level by default
            _selectedLevel = _levels.First;

            //Start the levelselector
            Start(LevelSelect());
        }

        //Select a level to play
        private Level LevelSelect()
        {
            //Show initial level select screen
            _outputView.LevelSelector(_levels, _selectedLevel);

            //Handle user input and return selected level when enter is pressed
            while (true)
            {
                switch (_inputView.LevelSelector())
                {
                    case ConsoleKey.Enter:
                        return _selectedLevel.Value;
                    case ConsoleKey.UpArrow:
                        _selectedLevel = _selectedLevel.Previous ?? _selectedLevel;
                        _outputView.LevelSelector(_levels, _selectedLevel);
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedLevel = _selectedLevel.Next ?? _selectedLevel;
                        _outputView.LevelSelector(_levels, _selectedLevel);
                        break;
                }
            }
        }

        //Start a level
        private void Start(Level level)
        {
            Console.ReadKey();
        }
    }
}