using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Tile
    {
        public Entity Entity { get; }

        public Tile Top { get; set; }
        public Tile Right { get; set; }
        public Tile Bottom { get; set; }
        public Tile Left { get; set; }

        public Tile(Entity entity)
        {
            Entity = entity;
        }
    }
}
