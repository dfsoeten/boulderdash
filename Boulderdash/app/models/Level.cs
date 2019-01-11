using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        
        public bool Won { get; set; } = false;

        public bool Lost { get; set; } = false;

        public Tile Start { get; set; }

        public Tile Exit { get; set; }

        private Tile _rockFord;
        
        public Tile RockFord
        {
            get => _rockFord;
            set => _rockFord = (_rockFord == null) ? value : throw new Exception("Rockford has been set twice!");
        }

        public List<Tile> Moveables = new List<Tile>();

        public void Tick()
        {
            //Update "timer"
            Time-=1/3D;
                        
            //Move every moveable three times per "second"
            for (int i = 0; i < 3; i++)
                Moveables.ToList().ForEach(m => { m.Entity.Move(m); });
            
            //Show exit if every diamond is collected
            if (!Moveables.Any(m => m.Is<Diamond>()))
                Exit.Entity = new Exit();
        }

        public bool IsOver()
        {
            //Check if the game is over
            return Won || Lost || Time < 0;
        }
    }
}
