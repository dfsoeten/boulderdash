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
        protected void WriteYellowLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Write red character
        protected void WriteRedCharacter(string character)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(character);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
