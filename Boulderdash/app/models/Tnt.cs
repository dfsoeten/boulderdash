using System;

namespace Boulderdash.app.models
{
    public class Tnt : Moveable
    {
        private bool hasMoved { get; set; } = false;
        
        public override char GetCharacter()
        {
            return '■';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Red;
        }

        public override void Move(Tile from, Tile to = null)
        {
            //Explode
            if (from.Bottom.Is<Air>())
                hasMoved = true;     
            else if(hasMoved)
                Explode(from);

            base.Move(from, to);
        }
    }
}