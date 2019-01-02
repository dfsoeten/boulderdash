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
            if(to == null)
                switch (_direction)
                {
                    case Direction.Top:
                        return Move(from, from.Top);
                    case Direction.Right:
                        return Move(from, from.Right);
                    case Direction.Bottom:
                        return Move(from, from.Bottom);
                    case Direction.Left:
                        return Move(from, from.Left);
                }

            if (to.IsAir())
            {
                to.Entity = from.Entity;
                from.Entity = new Air();
                return to;
            }
            else if (to.IsRockford())
            {
                to.Explode(to);
            }
            else
            {
                switch (_direction)
                {
                    case Direction.Top:
                        _direction = Direction.Right;
                        break;
                    case Direction.Right:
                        _direction = Direction.Bottom;
                        break;
                    case Direction.Bottom:
                        _direction = Direction.Left;
                        break;
                    case Direction.Left:
                        _direction = Direction.Top;
                        break;
                }

                return Move(from, null);
            }

            return from;
        }

        //Check if the firefly collides with RockFord
        public bool CollideWithExplodable(Tile to)
        {
            if (to.Top.IsRockford() || to.Top.IsBoulder() || to.Top.IsDiamond())
                return true;
            if (to.Right.IsRockford() || to.Right.IsBoulder() || to.Right.IsDiamond())
                return true;
            if (to.Bottom.IsRockford() || to.Bottom.IsBoulder() || to.Bottom.IsDiamond())
                return true;
            if (to.Left.IsRockford() || to.Left.IsBoulder() || to.Left.IsDiamond())
                return true;
            if (to.IsRockford() || to.IsBoulder() || to.IsDiamond())
                return true;

            return false;
        }

        //Destroy FireFly
        public override void Destroy(Tile tile)
        {
            tile.Entity = new Air();
        }
    }
}
