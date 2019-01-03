using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public class Level
    {
        public string Name { get; set; }

        public Tile Start { get; set; }

        public double ElapsedTime { private get; set; }

        public Tile RockFord { get; set; } 
        public List<Tile> FireFlies { get; private set; } = new List<Tile>();
        public List<Tile> Boulders { get; } = new List<Tile>();
        public List<Tile> Diamonds { get; } = new List<Tile>();

        public void MoveMoveables()
        {    
            //Move Entities
            foreach (Tile moveable in FireFlies.Concat(Boulders).Concat(Diamonds))
                moveable.Entity.Move(ElapsedTime, moveable);
        }

        public bool IsOver()
        {
            //Check if the game is over
            return RockFord.Top != null && RockFord.Top.IsBoulder();
        }
    }
}
