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
    public class Parser
    {
        //Create a linkedlist with level objects
        public LinkedList<Level> Levels { get; } = new LinkedList<Level>();

        //Parses all .txt level files in the levels directory
        public Parser(string levelsPath = @"../../levels")
        {
            Tile[][] tiles;

            foreach (var fileName in new DirectoryInfo(levelsPath).GetFiles("*.txt"))
            {
                //Create new level object
                Levels.AddLast(new Level() { Name = Path.GetFileNameWithoutExtension(fileName.Name) });

                //Create tiles array object
                tiles = File.ReadAllLines($@"{fileName}").Select(l => l.ToCharArray().Select(CreateTile).ToArray()).ToArray();

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
            Tile tile = new Tile { Level = Levels.Last() };
    
            switch (c)
            {
                case 'S': //Steelwall
                    tile.Entity = new Steelwall { Tile = tile }; break;
                case 'B': //Boulder
                    tile.Entity = new Boulder { Tile = tile }; Levels.Last().Moveables.Add(tile); break;
                case 'M': //Mud
                    tile.Entity = new Mud { Tile = tile }; break;
                case 'F': //Firefly
                    tile.Entity = new Firefly { Tile = tile }; Levels.Last().Moveables.Add(tile); break;
                case 'R': //Rockford
                    tile.Entity = new Rockford { Tile = tile }; Levels.Last().RockFord = tile; break;
                case 'D': //Diamond
                    tile.Entity = new Diamond { Tile = tile }; Levels.Last().Moveables.Add(tile); break;
                case 'W': //Wall
                    tile.Entity = new Wall { Tile = tile }; break;
                case 'X': //Exit
                    tile.Entity = new Air { Tile = tile }; Levels.Last().Exit = tile; break;
                case 'H': //Hardened Mud
                    tile.Entity = new HardenedMud { Tile = tile }; Levels.Last().HardenedMuds.Add(tile); break;
                default: //Air
                    tile.Entity = new Air { Tile = tile }; break;
            }
            
            return tile;
        }
    }
}
