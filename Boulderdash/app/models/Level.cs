using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Level
    {
        public string Name { get; set; }

        public Tile Start { get; set; }

        public Tile RockFord { get; set; } 
        public List<Tile> FireFlies { get; set; } = new List<Tile>();
        public List<Tile> Boulders { get; } = new List<Tile>();
        public List<Tile> Diamonds { get; } = new List<Tile>();

        public void MoveMoveables()
        {
            //Move Fireflies
            List<Tile> MovedFireflies = new List<Tile>();
            foreach (Tile FireFly in FireFlies)
                if (!FireFly.IsAir())
                    MovedFireflies.Add(FireFly.Entity.Move(FireFly));

            FireFlies = MovedFireflies;
        }

        public bool IsOver()
        {
            //Check if the game is over
            if (RockFord.Top != null && RockFord.Top.IsBoulder())
                return true;
            else
                return false;
        }
    }
}
