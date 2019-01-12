using System;

namespace Boulderdash.app.models
{
    public class Tnt : Moveable
    {
        public override char GetCharacter()
        {
            return 'T';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Red;
        }

        public override void Move(Tile from, Tile to = null)
        {
            //Explode
            if (!from.Bottom.Is<Air>())
                Explode(from);

            base.Move(from, to);
        }
    }
}