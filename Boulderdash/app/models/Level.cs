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
            for (int i = 0; i < 3; i++)
            {
                List<Tile> MovedFireflies = new List<Tile>();
                foreach (Tile FireFly in Fireflies)
                    if (FireFly.Is<Firefly>())
                        MovedFireflies.Add(FireFly.Entity.Move(FireFly));

                Fireflies = MovedFireflies;    
            }
        }

        public bool IsOver()
        {
            //Check if the game is over
            return RockFord.Top != null && RockFord.Top.Is<Boulder>();
        }
    }
}
