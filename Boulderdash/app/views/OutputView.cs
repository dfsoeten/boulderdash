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
        public OutputView()
        {
            //Set encoding to UTF8 to support unicode characters
            Console.OutputEncoding = Encoding.UTF8;
        }

        //Levelselector
        public void LevelSelector(LinkedList<Level> levels, LinkedListNode<Level> selectedLevel)
        {
            //Clear the console
            Console.Clear();

            //Boulderdash ACII
            WriteColoredLine(@"  ____              _     _              _           _      ", ConsoleColor.Yellow);
            WriteColoredLine(@" |  _ \            | |   | |            | |         | |     ", ConsoleColor.Yellow);
            WriteColoredLine(@" | |_) | ___  _   _| | __| | ___ _ __ __| | __ _ ___| |__   ", ConsoleColor.Yellow);
            WriteColoredLine(@" |  _ < / _ \| | | | |/ _` |/ _ \ '__/ _` |/ _` / __| '_ \  ", ConsoleColor.Yellow);
            WriteColoredLine(@" | |_) | (_) | |_| | | (_| |  __/ | | (_| | (_| \__ \ | | | ", ConsoleColor.Yellow);
            WriteColoredLine(@" |____/ \___/ \__,_|_|\__,_|\___|_|  \__,_|\__,_|___/_| |_| ", ConsoleColor.Yellow);

            //Levelselect
            Console.WriteLine("\n ==========================================================\n");
            Console.WriteLine(" Select a level to play:");
            foreach (Level level in levels)
            {
                WriteColoredCharacter(level == selectedLevel.Value ? " → " : "   ", ConsoleColor.Red); Console.WriteLine(level.Name);
            }
            Console.WriteLine("\n ==========================================================");
        }

        //Display the level
        public void Level(Level level)
        {
            //Clear the console
            Console.Clear();

            Tile currentNode = level.Start, startingNode = level.Start;

            while (currentNode != null)
            {
                while (currentNode != null)
                {
                    WriteColoredCharacter($"{currentNode.Character}", currentNode.Color);
                    currentNode = currentNode.Right;
                }

                Console.WriteLine();
                currentNode = startingNode.Bottom;
                startingNode = currentNode;
            }
        }

        public void GameOver()
        {
            //Clear the console
            Console.Clear();

            //GameOver ACII
            WriteColoredLine(@"  _____                         ____                 _ ", ConsoleColor.Red);
            WriteColoredLine(@" / ____|                       / __ \               | |", ConsoleColor.Red);
            WriteColoredLine(@"| |  __  __ _ _ __ ___   ___  | |  | |_   _____ _ __| |", ConsoleColor.Red);
            WriteColoredLine(@"| | |_ |/ _` | '_ ` _ \ / _ \ | |  | \ \ / / _ \ '__| |", ConsoleColor.Red);
            WriteColoredLine(@"| |__| | (_| | | | | | |  __/ | |__| |\ V /  __/ |  |_|", ConsoleColor.Red);
            WriteColoredLine(@" \_____|\__,_|_| |_| |_|\___|  \____/  \_/ \___|_|  (_)", ConsoleColor.Red);
        }
    }
}
