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

        public override Tile Move(Tile from, Tile to)
        {
            if (to.IsAir() && to.Bottom.IsAir())
                Move(from, to.Bottom);

            if (to.Bottom.IsBoulder())
            {
                if (to.Bottom.Right.IsAir())
                    Move(from, to.Bottom.Right);

                if (to.Bottom.Left.IsAir())
                    Move(from, to.Bottom.Left);
            }
                

            if (to.IsAir())
            {
                to.Entity = from.Entity;
                from.Entity = new Air();
                return to;
            }

            return from;
        }

        //Destroy Boulder
        public override void Destroy(Tile tile)
        {
            tile.Entity = new Air();
        }
    }
}
