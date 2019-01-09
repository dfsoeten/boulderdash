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

        public int Time { get; private set; } = 150;

        public int Score { get; private set; } = 0;

        public Tile Start { get; set; } 

        public Tile RockFord { get; set; }

        private List<Tile> _diamonds = new List<Tile>();
        
        public List<Tile> Diamonds {
            get
            {
                _diamonds.ToList().ForEach(d => { if (!d.Is<Diamond>()){ _diamonds.Remove(d); Score += 10; } }); 
                return _diamonds;
            }
        }

        private List<Tile> _boulders = new List<Tile>();
        
        public List<Tile> Boulders {
            get
            {
                _boulders.ToList().ForEach(b => { if (!b.Is<Boulder>()){ _diamonds.Remove(b); } }); 
                return _boulders;
            }
        }
        
        private List<Tile> _fireflies = new List<Tile>();
        
        public List<Tile> Fireflies {
            get
            {
                _fireflies.ToList().ForEach(f => { if (!f.Is<Firefly>()){ _fireflies.Remove(f); Score += 100; } }); 
                return _fireflies;
            }
        }

        public void Tick()
        {
            //Update "timer"
            Time-=3;
            
            //Move every moveable three times per "second"
            for (int i = 0; i < 3; i++)
            {
                //Move fireflies
                _fireflies = MoveMoveable(Fireflies);
                
                //Move Boulders
                //_boulders = MoveMoveable(Boulders); //@todo: fix bug here :]
                
                //Move Diamonds
                _diamonds = MoveMoveable(Diamonds);
            }
        }
        
        //Helper method to move moveables
        private List<Tile> MoveMoveable(List<Tile> tilesToMove)
        {
            List<Tile> movedTiles = new List<Tile>();
            foreach (Tile tile in tilesToMove)
                movedTiles.Add(tile.Entity.Move(tile));

            return movedTiles;
        }

        public bool IsOver()
        {
            //Check if the game is over
            return RockFord.Top != null && RockFord.Top.Is<Boulder>() || Time < 0;
        }
    }
}
