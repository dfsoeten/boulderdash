using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.views
{
    class BaseView
    {
        //Write yellow line
        protected void WriteColoredLine(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Write red character
        protected void WriteColoredCharacter(string character, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(character);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
