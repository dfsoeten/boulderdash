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

        public override void Move(Tile from, Tile to = null)
        {
            //Lose the game if a boulder falls on rockford
            if (from.Bottom.Is<Rockford>())
                Tile.Level.Lost = true;

            if (from.Bottom.Is<Firefly>())
            {
                from.Bottom.Entity.Destroy();
                Explode(from);
                return;
            }
            
            base.Move(from, to);
        }
    }
}
