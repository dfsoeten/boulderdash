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

            foreach (var fileName in new DirectoryInfo(_levelsPath).GetFiles("*.txt"))
            {
                //Create new level object
                Levels.AddLast(new Level());

                //Create tiles array object
                tiles = File.ReadAllLines($@"{_levelsPath}\{fileName}").Select(l => l.ToCharArray().Select(c => CreateTile(c)).ToArray()).ToArray();

                //Set start tile
                Levels.Last.Value.Start = tiles[0][0];

                for (int y = 0; y < tiles.Length; y++)
                {
                    for (int x = 0; x < tiles[y].Length; x++)
                    {
                        tiles[y][x].Top = (y - 1 >= 0) ? tiles[y - 1][x] : null;
                        tiles[y][x].Right = (x + 1 < tiles[y].Length) ? tiles[y][x + 1] : null;
                        tiles[y][x].Bottom = (y + 1 < tiles.Length) ? tiles[y + 1][x] : null;
                        tiles[y][x].Left = (x - 1 >= 0) ? tiles[y][x - 1] : null;
                    }
                }
            }
        }

        //Create tile objects with the right entity objects
        private Tile CreateTile(char c)
        {
            Tile tile;

            switch (c)
            {
                case 'S': //Steelwall
                    return new Tile(new Steelwall());
                case 'B': //Boulder
                    Levels.Last.Value.Boulders.Add(tile = new Tile(new Boulder())); return tile;
                case 'M': //Mud
                    return new Tile(new Mud());
                case 'F': //Firefly
                    Levels.Last.Value.FireFlies.Add(tile = new Tile(new Firefly())); return tile;
                case 'R': //Rockford
                    return Levels.Last.Value.RockFord = new Tile(new Rockford());
                case 'D': //Diamond
                    Levels.Last.Value.Diamonds.Add(tile = new Tile(new Diamond())); return tile;
                default: //Air
                    return new Tile(null);
            }
        }
    }
}
