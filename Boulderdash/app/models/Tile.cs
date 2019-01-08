using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public class Tile
    {
        public Entity Entity { get; set; }

        public Tile Top { get; set; }
        public Tile Right { get; set; }
        public Tile Bottom { get; set; }
        public Tile Left { get; set; }

        public char Character => Entity.GetCharacter();

        public ConsoleColor Color => Entity.GetColor();
        
        public bool Is<T>()
        {
            return Entity is T;
        }
    }
}
