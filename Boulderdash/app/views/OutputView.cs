using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boulderdash.app.models;

namespace Boulderdash.app.views
{
    class OutputView : BaseView
    {
        //Levelselector
        public void LevelSelector(LinkedList<Level> levels, LinkedListNode<Level> selectedLevel)
        {
            //Clear the console
            Console.Clear();

            //Boulderdash ACII
            WriteYellowLine(@" ____              _     _              _           _      ");
            WriteYellowLine(@"|  _ \            | |   | |            | |         | |     ");
            WriteYellowLine(@"| |_) | ___  _   _| | __| | ___ _ __ __| | __ _ ___| |__   ");
            WriteYellowLine(@"|  _ < / _ \| | | | |/ _` |/ _ \ '__/ _` |/ _` / __| '_ \  ");
            WriteYellowLine(@"| |_) | (_) | |_| | | (_| |  __/ | | (_| | (_| \__ \ | | | ");
            WriteYellowLine(@"|____/ \___/ \__,_|_|\__,_|\___|_|  \__,_|\__,_|___/_| |_| ");

            //Levelselect
            Console.WriteLine("\n==========================================================\n");
            Console.WriteLine("Select a level to play:");
            foreach (Level level in levels)
            {
                WriteRedCharacter(level == selectedLevel.Value ? "> " : "  "); Console.WriteLine(level.Name);
            }
        }
    }
}
