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
            if (to.Is<Mud>() || to.Is<Air>() || to.Is<Rubble>() || to.Is<Diamond>())
                Dig(from, to);
            
            //Don't destroy TnT :)
            if (to.Is<Tnt>())
                Dig(from, to, false);

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
        
        private void Dig(Tile from, Tile to, bool destroy = true)
        {
            
            if (destroy)
                to.Entity.Destroy(to);
            
            Tile.Level.Moveables.Remove(Tile.Level.Moveables.Find(m => m.Entity == to.Entity));
            to.Entity = from.Entity;
            from.Entity = new Air();
            Tile.Level.RockFord = to;
        }
    }
}
