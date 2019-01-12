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
        public override void Move(Tile from, Tile to = null)
        {    
            //Win the game if you touch the exit
            if (to.Is<Exit>())
                Tile.Level.Won = true;
            
            //Rockford's diggables
            if (to.Is<Mud>() || to.Is<Air>() || to.Is<Rubble>() || to.Is<Diamond>() || to.Is<Tnt>())
                Dig(from, to);   

            //Push boulders
            if (to.Is<Boulder>())
            {
                if (from.Left == to && to.Left.Is<Air>())
                {
                    Slide(to, to.Left);
                    Dig(from, to);

                }
                if (from.Right == to && to.Right.Is<Air>())
                {
                    Slide(to, to.Right);
                    Dig(from, to);
                }
            }            
        }

        public override void Destroy(Tile destroyable = null)
        {
            Tile.Level.Lost = true;
            
            base.Destroy(destroyable);
        }
    }
}
