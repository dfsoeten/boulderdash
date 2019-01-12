using System;

namespace Boulderdash.app.models
{
    public class Rubble : Moveable
    {
        public override char GetCharacter()
        {
            return '*';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Gray;
        }

        public override void Move(Tile from, Tile to = null)
        {
            //Lose the game if a rubble falls on rockford
            if (from.Bottom.Is<Firefly>() || from.Bottom.Is<Rockford>() || from.Bottom.Is<Tnt>())
                from.Bottom.Entity.Destroy(from.Bottom);
            
            base.Move(from, to);
        }
    }
}