using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Boulderdash.app.models
{
    class Steelwall : Wall
    {
        public override char GetCharacter()
        {
            return '■';
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkGray;
        }

        public override void Destroy()
        {

        }
    }
}
