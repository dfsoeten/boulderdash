using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    public class Air : Entity
    {
        public override char GetCharacter()
        {
            return ' ';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.White;
        }

        //Destroy Air
        public override void Destroy(Tile destroyable)
        {

        }
    }
}
