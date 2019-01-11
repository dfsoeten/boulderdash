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
            if (from.Bottom.Is<Air>())
                return Slide(from, from.Bottom);
            
            if (from.Bottom.Is<Boulder>())
            {
                if (from.Bottom.Right.Is<Air>())
                    return Slide(from, from.Bottom.Right);

                if (from.Bottom.Left.Is<Air>())
                    return Slide(from, from.Bottom.Left);
            }
            
            //Pushed by rockford
            if (to != null && to.Is<Air>())
            {
                return Slide(from, to);
            }
         
            return from;
        }

        //Destroy Boulder
        public override void Destroy()
        {
            Tile.Entity = new Air();
        }
    }
}
