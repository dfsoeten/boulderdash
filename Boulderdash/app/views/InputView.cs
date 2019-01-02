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
                    case ConsoleKey.Escape:
                        return ConsoleKey.Escape;
                }
            }
        }

        //Get Level Key
        public ConsoleKey Level()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        return ConsoleKey.UpArrow;
                    case ConsoleKey.RightArrow:
                        return ConsoleKey.RightArrow;
                    case ConsoleKey.DownArrow:
                        return ConsoleKey.DownArrow;
                    case ConsoleKey.LeftArrow:
                        return ConsoleKey.LeftArrow;
                    case ConsoleKey.Escape:
                        return ConsoleKey.Escape;
                }
            }
        }
    }
}
