using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Boulder : Moveable
    {
        public override char GetCharacter()
        {
            return 'o';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkRed;
        }

        public override Tile Move(double et, Tile from, Tile to)
        {
            return from;
        }

        //Destroy Boulder
        public override void Destroy(Tile tile)
        {
            tile.Entity = new Air();
        }
    }
}
