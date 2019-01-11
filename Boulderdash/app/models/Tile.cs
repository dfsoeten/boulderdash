using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boulderdash.Enums;

namespace Boulderdash.app.models
{
    public class Tile
    {   
        public Level Level { get; set; }
        
        public Entity Entity { get; set; }

        public Tile Top { get; set; }
        public Tile Right { get; set; }
        public Tile Bottom { get; set; }
        public Tile Left { get; set; }

        public char Character => Entity.GetCharacter();

        public ConsoleColor Color => Entity.GetColor();
        
        //Get the tile from a direction
        public Tile GetTileFromDirection(Direction direction, Tile from)
        {
            switch (direction)
            {
                case Direction.Top:
                    return from.Top;
                case Direction.Right:
                    return from.Right;
                case Direction.Bottom:
                    return from.Bottom;
                case Direction.Left:
                    return from.Left;
            }

            return from;
        }
        
        public bool Is<T>()
        {
            return Entity is T;
        }
        
        public int SurroundedBy<T>(Tile from)
        {
            return new[] {Direction.Top, Direction.Right, Direction.Bottom, Direction.Left}.Count(direction => GetTileFromDirection(direction, from).Is<T>());
        }
    }
}
