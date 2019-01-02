using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Wall : Entity
    {
        public override char GetCharacter()
        {
            return '■';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Gray;
        }

        //Destroy Wall
        public override void Destroy(Tile tile)
        {
            tile.Entity = new Air();
        }
    }
}
