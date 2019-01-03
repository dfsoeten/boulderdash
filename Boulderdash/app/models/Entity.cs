using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public abstract class Entity : Tile
    {
        public bool Destroyed = false;
        
        public abstract char GetCharacter();

        public abstract ConsoleColor GetColor();

        public virtual void Destroy(Tile tile) { Destroyed = true; }
        

        public virtual Tile Move(Tile @from, Tile to = null) { return from; }
    }
}
