using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public class Level
    {   
        public string Name { get; set; }

        public Tile Start { get; set; } 

        public Tile RockFord { get; set; }

        public List<Tile> Diamonds { get; set; } = new List<Tile>();

        public List<Tile> Boulders { get; set; } = new List<Tile>();
        
        public List<Tile> Fireflies { get; set; } = new List<Tile>();

        public void MoveMoveables()
        {
            //Move each moveable three times every "tick"
            
            //Move Fireflies
            foreach (Tile FireFly in new List<Tile>(Fireflies))
                if (FireFly.Is<Firefly>()) Fireflies.Add(FireFly.Entity.Move(FireFly));
        }

        public bool IsOver()
        {
            //Check if the game is over
            return RockFord.Top != null && RockFord.Top.Is<Boulder>();
        }
    }
}
