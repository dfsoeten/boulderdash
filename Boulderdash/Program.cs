using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash
{
    class Program
    {
        private static Game _game;

        static void Main(string[] args) => (_game = new Game()).Start();
    }
}
