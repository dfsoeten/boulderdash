using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Diamond : Moveable
    {
        public override char GetCharacter()
        {
            return '♦';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Cyan;
        }

        //Move Diamond
        public override Tile Move(double et, Tile from, Tile to)
        {
            return from;
        }

        //Destroy Diamond
        public override void Destroy(Tile tile)
        {
            tile.Entity = new Air();
        }
    }
}
