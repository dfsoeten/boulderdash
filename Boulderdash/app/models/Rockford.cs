using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public class Rockford : Moveable
    {   
        public override char GetCharacter()
        {
            return 'R';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Blue;
        }

        //Move rockford
        public override Tile Move(Tile from, Tile to)
        {
            if (to.Is<Mud>() || to.Is<Air>())
                return Dig(from, to);

            if (to.Is<Diamond>())
            {
                to.Entity.Destroy();
                return Dig(from, to);
            }

            if (to.Is<Boulder>())
            {
                if (from.Left == to && to.Left.Is<Air>())
                {
                    to.Entity.Move(to, to.Left);
                    return Dig(from, to);

                }
                if (from.Right == to && to.Right.Is<Air>())
                {
                    to.Entity.Move(to, to.Right);
                    return Dig(from, to);
                }
            }            

            return from;
        }

        //Destroy Rockford
        public override void Destroy()
        {
            //xd
        }
    }
}
