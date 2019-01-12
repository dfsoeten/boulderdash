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
            //Moveables fall down
            if (from.Bottom.Is<Air>()){
                Slide(from, from.Bottom);
                return;
            }    
            
            //Moveables slide of one another
            if (from.Bottom.Is<Boulder>() || from.Bottom.Is<Diamond>())
            {
                if (from.Bottom.Right.Is<Air>())
                    Slide(from, from.Bottom.Right);

                else if (from.Bottom.Left.Is<Air>())
                    Slide(from, from.Bottom.Left);
            }
        }
        
        protected void Slide(Tile from, Tile to)
        {
            Tile.Level.Moveables.Remove(from);
            
            to.Entity = from.Entity;
            from.Entity = new Air();
            
            Tile.Level.Moveables.Add(to);
        }
    }
}
