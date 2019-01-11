using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public abstract class Entity
    {
        public Tile Tile { get; set; }
                
        public abstract char GetCharacter();

        public abstract ConsoleColor GetColor();

        public virtual void Destroy() { }
        
        public virtual Tile Move(Tile from, Tile to = null) { return from; }
    }
}
