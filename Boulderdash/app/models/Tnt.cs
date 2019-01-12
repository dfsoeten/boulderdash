using System;

namespace Boulderdash.app.models
{
    public class Tnt : Moveable
    {
        private bool HasMoved { get; set; }
        
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
                HasMoved = true;     
            else if(HasMoved)
                Destroy(from);

            base.Move(from, to);
        }

        public override void Destroy(Tile destroyable = null)
        {
            base.Destroy(destroyable);
            Explode(destroyable);
        }
    }
}