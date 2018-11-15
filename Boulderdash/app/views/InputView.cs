using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Boulderdash.app.views
{
    class InputView
    {
        //Get Levelselector Key
        public ConsoleKey LevelSelector()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        return ConsoleKey.UpArrow;
                    case ConsoleKey.DownArrow:
                        return ConsoleKey.DownArrow;
                    case ConsoleKey.Enter:
                        return ConsoleKey.Enter;
                }
            }
        }
    }
}
