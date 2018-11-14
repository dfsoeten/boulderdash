using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Level
    {
        public Tile _start;
        public Tile RockFord { get; }
        public List<Tile> FireFlies { get; }
        public List<Tile> Boulders { get; }
        public List<Tile> Diamonds { get; }

        public Level()
        {

        }
    }
}
