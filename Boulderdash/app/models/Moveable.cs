using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    abstract class Moveable : Entity
    {
        public override abstract Tile Move(Tile from, Tile to);
    }
}
