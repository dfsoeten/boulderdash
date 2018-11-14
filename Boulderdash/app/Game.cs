using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boulderdash.app.controller;
using Boulderdash.app.models;

namespace Boulderdash
{
    public class Game
    {
        private LinkedList<Level> _levels;

        public Game()
        {
            _levels = new Parser().Levels;
        }

        public void Start()
        {
            Console.ReadKey();
        }
    }
}