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
        private Direction _direction = Direction.Top;

        public override char GetCharacter()
        {
            return 'f';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkYellow;
        }

        public override Tile Move(Tile from, Tile to)
        {
            //Lose the game if you get hit by a firefly
            if (GetNextDirectionTile(from).Is<Rockford>())
                Tile.Level.Lost = true;
            
            //Change direction if the firefly can't move
            if (to == null)
            {
                if (!(to = GetNextDirectionTile(from)).Is<Air>())
                    ChangeDirection();
                
                return Move(from, to);
            }

            if (to.Is<Air>())
                return Slide(from, to);

            return from;
        }

        //Get the tile from a direction
        private Tile GetNextDirectionTile(Tile from)
        {
            switch (_direction)
            {
                case Direction.Top:
                    return from.Top;
                case Direction.Right:
                    return from.Right;
                case Direction.Bottom:
                    return from.Bottom;
                case Direction.Left:
                    return from.Left;
            }

            return from;
        }
        
        //Change the direction of the firefly
        private void ChangeDirection()
        {
            switch (_direction)
            {
                case Direction.Top:
                    _direction = Direction.Right; break;
                case Direction.Right:
                    _direction = Direction.Bottom; break;
                case Direction.Bottom:
                    _direction = Direction.Left; break;
                case Direction.Left:
                    _direction = Direction.Top; break;
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
