using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Boulderdash.app.models;

namespace Boulderdash.app.controller
{
    class Parser
    {
        //Relative path to the level directory
        private readonly string _levelsPath = @"..\..\levels";

        //Create a linkedlist with level objects
        public LinkedList<Level> Levels { get; } = new LinkedList<Level>();

        //Parses all .txt level files in the levels directory
        public Parser()
        {
            Tile[][] tiles;
            char[] letters;



            foreach (var fileName in new DirectoryInfo(_levelsPath).GetFiles("*.txt"))
            {
                //Create tiles array object
                tiles = File.ReadAllLines($@"{_levelsPath}\{fileName}").Select(l => l.ToCharArray().Select(c => CreateTile(c)).ToArray()).ToArray();

                //Create new level object
                Levels.AddLast(new Level() { _start = tiles[0][0]});

                for (int y = 0; y < tiles.Length; y++)
                {
                    for (int x = 0; x < tiles[y].Length; x++)
                    {
                        //@todo: link tiles here
                    }
                }
            }
        }

        private Tile CreateTile(char c)
        {
            switch (c)
            {
                case 'S': //Steelwall
                    return new Tile(new Steelwall());
                case 'B': //Boulder
                    return new Tile(new Boulder());
                case 'M': //Mud
                    return new Tile(new Mud());
                case 'F': //Firefly
                    return new Tile(new Firefly());
                case 'R': //Rockford
                    return new Tile(new Rockford());
                case 'D': //Diamond
                    return new Tile(new Diamond());
                default: //Air
                    return new Tile(null);
            }
        }
    }
}
