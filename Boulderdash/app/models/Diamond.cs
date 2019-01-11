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
        public override Tile Move(Tile from, Tile to = null)
        {
            return from;
        }

        //Destroy Diamond
        public override void Destroy()
        {
            Tile.Level.Score += 10;
            Tile.Level.Moveables.Remove(Tile);
        }
    }
}
