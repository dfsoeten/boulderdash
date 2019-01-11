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

        public double Time { get; private set; } = 150;

        public int Score { get; set; } = 0;

        public Tile Start { get; set; } 

        public Tile RockFord { get; set; }
        
        public List<Tile> Moveables = new List<Tile>();

        public void Tick()
        {
            //Update "timer"
            Time-=1/3D;
                        
            //Move every moveable three times per "second"
            for (int i = 0; i < 3; i++)
                Moveables.ToList().ForEach(m => { m.Entity.Move(m); });
        }

        public bool IsOver()
        {
            //Check if the game is over
            return RockFord.Top != null && RockFord.Top.Is<Boulder>() || Time < 0;
        }
    }
}
