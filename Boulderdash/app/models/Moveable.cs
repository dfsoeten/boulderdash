using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public abstract class Moveable : Entity
    {
        public abstract override Tile Move(Tile from, Tile to = null);

        protected Tile Dig(Tile from, Tile to)
        {
            to.Entity = from.Entity;
            from.Entity = new Air();
            return to;
        }

        protected Tile Slide(Tile from, Tile to)
        {
            Tile.Level.Moveables.Remove(from);
            Tile.Level.Moveables.Add(to);
            
            to.Entity = from.Entity;
            from.Entity = new Air();
            return to;
        }
    }
}
