using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boulderdash.Enums;

namespace Boulderdash.app.models
{
    class Firefly : Moveable
    {
        private Direction _direction = Direction.Left;

        public override char GetCharacter()
        {
            return 'f';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkYellow;
        }

        public override void Move(Tile from, Tile to = null)
        {
            //Lose the game if you get hit by a firefly
//            if (Tile.GetTileFromDirection(_direction, from).Is<Rockford>())
//                Tile.Level.Lost = true;
//            
//            //Change direction if the firefly can't move
//            if (to == null)
//            {   
//                if(!(to = Tile.GetTileFromDirection(_direction, from)).Is<Air>())
//                    Turn();
//                
//                Move(from, to);
//            }
//
//            if (to.Is<Air>())
//                Slide(from, to);
        }
        
        //Change the direction of the firefly
        private void Turn()
        {
            switch (_direction)
            {
                case Direction.Left:
                    _direction = Direction.Top; break;
                case Direction.Top:
                    _direction = Direction.Right; break;
                case Direction.Right:
                    _direction = Direction.Bottom; break;
                case Direction.Bottom:
                    _direction = Direction.Left; break;
                    
            }
        }

        //Destroy FireFly
        public override void Destroy()
        {
            Tile.Level.Score += 250;
            Tile.Level.Moveables.Remove(Tile.Level.Moveables.Find(m => m.Entity == this));
        }
    }
}
