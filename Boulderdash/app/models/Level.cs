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

        public double ElapsedTime { private get; set; }

        public Tile RockFord { get; set; } 
        
        private List<Tile> _diamonds = new List<Tile>();
        public List<Tile> Diamonds {
            get
            {
                _diamonds.ToList().ForEach(d => { if (d.Is<Air>() || d.Is<Rockford>()) _diamonds.Remove(d); });
                return _diamonds;
            }
            set => _diamonds = value;
        }
        
        public List<Tile> Boulders { get; set; } = new List<Tile>();
        
        public List<Tile> Fireflies { get; set; } = new List<Tile>();

        public bool IsOver()
        {
            //Check if the game is over
            return RockFord.Top != null && RockFord.Top.Is<Boulder>();
        }
    }
}
