using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public abstract class Moveable : Entity
    {
        public override void Move(Tile from, Tile to = null)
        {
            //Boulders fall down
            if (from.Bottom.Is<Air>()){
                Slide(from, from.Bottom);
                return;
            }    
            
            //Boulders slide of one another
            if (from.Bottom.Is<Boulder>() || from.Bottom.Is<Diamond>())
            {
                if (from.Bottom.Right.Is<Air>())
                    Slide(from, from.Bottom.Right);

                else if (from.Bottom.Left.Is<Air>())
                    Slide(from, from.Bottom.Left);
            }
            
            //Destroy a firefly if a moveable falls on it
            if (from.Bottom.Is<Firefly>())
            {
                from.Bottom.Entity.Destroy();
                Slide(from, from.Bottom);
            }  
        }
        
        protected void Dig(Tile from, Tile to)
        {
            if(to.Is<Moveable>())
                Tile.Level.Moveables.Remove(to);
            
            to.Entity = from.Entity;
            from.Entity = new Air { Tile = from };
            Tile.Level.RockFord = to;
        }
        
        protected void Slide(Tile from, Tile to)
        {
            Tile.Level.Moveables.Remove(from);
            
            to.Entity = from.Entity;
            from.Entity = new Air();
            
            Tile.Level.Moveables.Add(to);
        }
        
        protected void Explode(Tile center, int blastRadius = 3)
        {
            if (--blastRadius > 0)
            {
                Explode(center.Left, blastRadius);
                Explode(center.Right, blastRadius);    
                Explode(center.Top, blastRadius);
                Explode(center.Bottom, blastRadius);
            }
            
            Destroy(center);
        }
    }
}
