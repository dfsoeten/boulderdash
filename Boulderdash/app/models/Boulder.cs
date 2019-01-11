using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Boulder : Moveable
    {
        public override char GetCharacter()
        {
            return 'o';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkRed;
        }

        public override Tile Move(Tile from, Tile to = null)
        {
            //Lose the game if a boulder falls on rockford
            if (from.Bottom.Is<Rockford>())
                Tile.Level.Lost = true;
            
            //Destroy a firefly if a rock falls on it
            if (from.Bottom.Is<Firefly>())
            {
                from.Bottom.Entity.Destroy();
                return Slide(from, from.Bottom);
            }
                
            
            //Boulders fall down
            if (from.Bottom.Is<Air>())
                return Slide(from, from.Bottom);
            
            //Boulders slide of one another
            if (from.Bottom.Is<Boulder>())
            {
                if (from.Bottom.Right.Is<Air>())
                    return Slide(from, from.Bottom.Right);

                if (from.Bottom.Left.Is<Air>())
                    return Slide(from, from.Bottom.Left);
            }
            
            //Pushed by rockford
            if (to != null && to.Is<Air>())
                return Slide(from, to);
         
            return from;
        }

        //Destroy Boulder
        public override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
