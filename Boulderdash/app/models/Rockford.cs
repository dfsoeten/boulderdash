using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Rockford : Moveable
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
                return Trail(from, to);

            if (to.Is<Diamond>())
            {
                return Trail(from, to);
            }
                


//            {
//                
//                
//                to.Entity = from.Entity;
//                from.Entity = new Air();
//                return to;
//            }
            

//            if (to.IsBoulder())
//            {
//                if (from.Left == to && to.Left.IsAir())
//                {
//                    to.Entity.Move(to, to.Left);
//                    to.Entity = from.Entity;
//                    from.Entity = new Air();
//                    return to;
//                }
//
//                if (from.Right == to && to.Right.IsAir())
//                {
//                    to.Entity.Move(to, to.Right);
//                    to.Entity = from.Entity;
//                    from.Entity = new Air();
//                    return to;
//                }
//            }

            return from;
        }

        //Destroy Rockford
        public override void Destroy(Tile tile)
        {

        }
    }
}
