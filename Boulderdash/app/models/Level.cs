using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Level
    {
        public Tile Start { get; set; }
        public Tile RockFord { get; set; } 
        public List<Tile> FireFlies { get; } = new List<Tile>();
        public List<Tile> Boulders { get; } = new List<Tile>();
        public List<Tile> Diamonds { get; } = new List<Tile>();

        public Level()
        {

        }
    }
}
