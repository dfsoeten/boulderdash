using System;

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
        public override void Move(Tile @from, Tile to = null)
        {    
            //Win the game if you touch the exit
            if (to.Is<Exit>())
                Tile.Level.Won = true;
            
            //Dig through mud
            if (to.Is<Mud>() || to.Is<Air>())
                Dig(from, to);

            //Dig through hardened mud if possible
            if (to.Is<HardenedMud>())
                to.Entity.Interact();

            //Collect diamonds
            if (to.Is<Diamond>())
            {
                to.Entity.Destroy();
                Dig(from, to);
            }

            //Push boulders
            if (to.Is<Boulder>())
            {
                if (from.Left == to && to.Left.Is<Air>())
                {
                    to.Entity.Move(to, to.Left);
                    Dig(from, to);

                }
                if (from.Right == to && to.Right.Is<Air>())
                {
                    to.Entity.Move(to, to.Right);
                    Dig(from, to);
                }
            }            
        }

        //Destroy Rockford
        public override void Destroy()
        {
            //xd
        }
    }
}
