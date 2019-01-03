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
        //private Direction _direction = Direction.Top;

        public override char GetCharacter()
        {
            return 'f';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkYellow;
        }

        public override Tile Move(Tile @from, Tile to = null)
        {
            return from;
        }

        //Destroy FireFly
        public override void Destroy(Tile tile)
        {
            tile.Entity = new Air();
        }
    }
}
